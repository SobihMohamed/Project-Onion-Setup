using System;
using AutoMapper;
using E_commerce.Domain.Contracts.UnitOfWorkPattern;
using E_commerce.Shared.Common.Dto.Category;
using E_commerce.Shared.Common.Pagination;
using E_commerce.Shared.Common.Params.Category;
using SoftBridge.Abstraction.IServices.Category;
using SoftBridge.Domain.Exceptions;
using SoftBridge.Domain.Models.ServiceAggregates;
using SoftBridge.Services.Specification;
using SoftBridge.Services.Specification.CategorySpecifications;
using SoftBridge.Services.Specification.CategorySpecifications.GetAllCategoriesAsync;
using SoftBridge.Services.Specification.CategorySpecifications.GetCategoryByIdAsync;

namespace SoftBridge.Services.Services.CategoryImplementation;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PaginationResponse<CategoryDto>> GetAllCategoriesAsync(CategoryQueryParams parameters)
    {
        var categoryRepo = _unitOfWork.GetRepository<Category, Guid>();

        var spec = new CategoryFiltrationSpecification(parameters);
        var categories = await categoryRepo.GetAllWithSpecAsync(spec);

        var countSpec = new CategoryCountSpecification(parameters);
        var totalItems = await categoryRepo.GetCountAsync(countSpec);

        return new PaginationResponse<CategoryDto>(parameters.PageIndex, parameters.PageSize, totalItems, _mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoryDto>>(categories));
    }

    public async Task<CategoryWithServicesDto> GetCategoryByIdAsync(Guid id)
    {
        var categoryRepo = _unitOfWork.GetRepository<Category, Guid>();

        var spec = new CategoryIncludesServicesSpecification(id);
        var category = await categoryRepo.GetByIdWithSpecAsync(spec);

        if (category is null)
            throw new NotFoundExceptionCustome("Category not found");

        return _mapper.Map<Category, CategoryWithServicesDto>(category);
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryToCreateDto categoryDto)
    {
        var categoryRepo = _unitOfWork.GetRepository<Category, Guid>();

        var category = _mapper.Map<CategoryToCreateDto, Category>(categoryDto);

        category.Id = Guid.NewGuid();

        await categoryRepo.AddAsync(category);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<Category, CategoryDto>(category);
    }


    public async Task<CategoryDto> UpdateCategoryAsync(Guid id, CategoryToUpdateDto categoryToUpdateDto)
    {
        var categoryRepo = _unitOfWork.GetRepository<Category, Guid>();

        var category = await categoryRepo.GetByIdAsync(id);

        if (category is null)
            throw new NotFoundExceptionCustome("Category not found");

        _mapper.Map<CategoryToUpdateDto, Category>(categoryToUpdateDto, category);

        categoryRepo.Update(category);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<Category, CategoryDto>(category);
    }

    public async Task<bool> DeleteCategoryAsync(Guid id)
    {
        var categoryRepo = _unitOfWork.GetRepository<Category, Guid>();

        var spec = new CategoryIncludesServicesSpecification(id);
        var category = await categoryRepo.GetByIdWithSpecAsync(spec);

        if (category is null)
            throw new NotFoundExceptionCustome("Category not found");

        if (category.Services.Any())
            throw new BadRequestExceptionCustome("Cannot delete category with existing services. Reassign or delete them first.");    

        categoryRepo.Delete(category);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

}
