using System;

namespace E_commerce.Shared.Common.Params.Category;

public class CategoryQueryParams : BaseQueryParams
{
    public string? Name { get; set; }
    public bool? IsActive { get; set; }
}
