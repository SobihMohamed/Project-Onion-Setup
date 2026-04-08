using System;
using E_commerce.Domain.Models.Shared;
using E_commerce.Domain.Models.User;

namespace SoftBridge.Domain.Models.Shared;

public class Client : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public string ProfileImageUrl { get; set; } = string.Empty;

    // Navigation property
    public ApplicationUser User { get; set; } = null!;
    public ICollection<ServiceRequest> ServiceRequests { get; set; } = new HashSet<ServiceRequest>();
    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
}
