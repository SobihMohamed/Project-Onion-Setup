using System;
using E_commerce.Domain.Models.Shared;
using SoftBridge.Domain.Models.EnumHelper;

namespace SoftBridge.Domain.Models.ServiceAggregates;

public class Service : BaseEntity<Guid>
{
    public Guid ProviderId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DeliveryDays { get; set; }
        public ServiceStatus Status { get; set; } = ServiceStatus.Pending;
        public string? RejectionReason { get; set; }
        public float AverageRating { get; set; } = 0f; // store this in DB to avoid calculating it every time, update it when a new review is added

        // Navigation properties
        public ServiceProvider Provider { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public ICollection<ServiceImage> Images { get; set; } = new HashSet<ServiceImage>();
        public ICollection<ServiceRequest> ServiceRequests { get; set; } = new HashSet<ServiceRequest>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
}
