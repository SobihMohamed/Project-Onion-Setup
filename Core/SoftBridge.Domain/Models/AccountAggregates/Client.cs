using System;
using SoftBridge.Domain.Models.Shared;
<<<<<<< HEAD
using SoftBridge.Domain.Models.User;
=======
>>>>>>> 2d8a7662502cc08f2d4a72432349b54d9f85f25a
using SoftBridge.Domain.Models.OrderAggregates;
using SoftBridge.Domain.Models.User;

namespace SoftBridge.Domain.Models.AccountAggregates;


public class Client : BaseEntity<Guid>
{
    public string UserId { get; set; }
    public string ProfileImageUrl { get; set; } = string.Empty;

    // Navigation property
    public ApplicationUser User { get; set; } = null!;
    public ICollection<ServiceRequest> ServiceRequests { get; set; } = new HashSet<ServiceRequest>();
    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
}
