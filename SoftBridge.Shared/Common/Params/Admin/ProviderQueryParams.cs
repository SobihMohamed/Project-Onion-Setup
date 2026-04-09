using SoftBridge.Domain.Models.EnumHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Shared.Common.Params.Admin
{
    public class ProviderQueryParams : BaseQueryParams
    {
        // 1. Search: To search by Provider's Name, Email, or Phone Number
        public string? SearchTerm { get; set; }

        // 2. Status Filter: To get Pending, Approved, or Rejected providers
        public ProviderAccountStatus? Status { get; set; }

        // 3. Verification Filter: Based on the "IsVerified" feature we added earlier
        public bool? IsVerified { get; set; }

        // 4. Rating Filter: To fetch top-rated providers (e.g., >= 4.0)
        public float? MinRating { get; set; }

        // 5. Date Range Filters: To get providers registered in a specific month/year
        public DateTime? RegisteredFrom { get; set; }
        public DateTime? RegisteredTo { get; set; }
    }
}
