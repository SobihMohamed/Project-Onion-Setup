using System;
using System.Collections.Generic;
using System.Text;

namespace SoftBridge.Abstraction.IServices.Profiles
{
    // This interface defines the contract for Admin-specific operations.
    // Primarily focuses on managing users (Providers and Clients) and their statuses.
    public interface IAdminService
    {
        // Retrieves all service providers with filtering (Status, SearchTerm, etc.)
        //Task<Pagination<ProviderProfileDto>> GetAllProvidersAsync(ProviderQueryParams queryParams);

        // Retrieves all clients with filtering (SearchTerm, Active/Inactive)
        //Task<Pagination<ClientProfileDto>> GetAllClientsAsync(ClientQueryParams queryParams);

        //Task<bool> ApproveProviderAsync(Guid providerId, Guid adminId);
        //Task<bool> RejectProviderAsync(Guid providerId, Guid adminId, string reason);
    }
}

// --- Query Params Classes (To be placed in  Shared/Common/Admin folder) ---
/*
public class ClientQueryParams : BaseQueryParams
{
    public string? SearchTerm { get; set; } // Search by name or email
    public bool? IsActive { get; set; } // Filter by active/banned clients
}

// This class extends BaseQueryParams to add filtering specific to Service Providers
    public class ProviderQueryParams : BaseQueryParams
    {
        // 1. Search: To search by Provider's Name, Email, or Phone Number
        public string? SearchTerm { get; set; }

        // 2. Status Filter: To get Pending, Approved, or Rejected providers
        public AccountStatus? Status { get; set; }

        // 3. Verification Filter: Based on the "IsVerified" feature we added earlier
        public bool? IsVerified { get; set; }

        // 4. Rating Filter: To fetch top-rated providers (e.g., >= 4.0)
        public float? MinRating { get; set; }

        // 5. Date Range Filters: To get providers registered in a specific month/year
        public DateTime? RegisteredFrom { get; set; }
        public DateTime? RegisteredTo { get; set; }
    }
*/