using SoftBridge.Domain.Models.EnumHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Shared.Common.Params.Service
{
    public class ServiceQueryParamsBaseQueryParams
    {
        public string? SearchTerm { get; set; } // Search by Title or Description
        public int? CategoryId { get; set; } // Filter by Category
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public float? MinRating { get; set; } // e.g., show services with 4+ stars
        public ServiceStatus? Status { get; set; } // Pending, Approved, Rejected
    }
}
