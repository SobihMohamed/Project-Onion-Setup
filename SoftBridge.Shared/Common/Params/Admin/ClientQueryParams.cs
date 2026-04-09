using System;
using System.Collections.Generic;
using System.Text;

namespace E_commerce.Shared.Common.Params.Admin
{
    public class ClientQueryParams : BaseQueryParams
    {
        public string? SearchTerm { get; set; } // Search by name or email
        public bool? IsActive { get; set; } // Filter by active/banned clients
    }
}
