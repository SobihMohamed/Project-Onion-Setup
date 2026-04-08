using E_commerce.Domain.Models;
using SoftBridge.Domain.Models.EnumHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SoftBridge.Domain.Models
{
    //+ ICollection < Review > Reviews
    public class ServiceProvider: BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public string? Bio { get; set; } = string.Empty;
        public string? ProfileImageUrl { get; set; } = string.Empty;
        public string? CvUrl { get; set; } = string.Empty;
        public string? PortfolioLink { get; set; } = string.Empty;
        public ProviderAccountStatus Status { get; set; } = ProviderAccountStatus.Pending;
        public float AverageRating { get; set; } = 0f;
        public int TotalReviews { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public Guid ApproveByAdminId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual Admin? ApprovedByAdmin { get; set; }
        public virtual ICollection<Service> Services { get; set; } = new HashSet<Service>();
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new HashSet<ServiceRequest>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}
