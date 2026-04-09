using System;
using E_commerce.Domain.Contracts.Specifications.BaseSpec;
using E_commerce.Shared.Common.Params.Category;
using SoftBridge.Domain.Models.ServiceAggregates;

namespace SoftBridge.Services.Specification.CategorySpecifications.GetAllCategoriesAsync;


//Code smell with the duplication of the filtration logic in both the CategoryFiltrationSpecification and CategoryCountSpecification
// Todo : Refactor later
public class CategoryCountSpecification : BaseSpecifications<Category, Guid>
{
    public CategoryCountSpecification(CategoryQueryParams categoryParams) : base(c =>
        (!categoryParams.IsActive.HasValue || c.IsActive == categoryParams.IsActive.Value) &&
        (string.IsNullOrEmpty(categoryParams.Search) || c.Name.ToLower().Contains(categoryParams.Search))
    )
    {
        
    }
}
