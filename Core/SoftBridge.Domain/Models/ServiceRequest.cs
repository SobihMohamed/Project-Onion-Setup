using E_commerce.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using SoftBridge.Domain.Models.EnumHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SoftBridge.Domain.Models.ServiceRequest
{
    public class ServiceRequest: BaseEntity<Guid>
    {
        public Guid ServiceId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProviderId { get; set; }
        public string Message { get; set; } = string.Empty;
        public decimal AgreedPrice { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public string? RejectionReason { get; set; }
        public DateTime? AcceptedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        //public virtual Service Service { get; set; } = null!;
        //public virtual Client Client { get; set; } = null!;
        //public virtual Provider Provider { get; set; } = null!;
        //public virtual Review? Review { get; set; }
        //public virtual ICollection<Message> Messages { get; set; } = new HashSet<Message>();

    }
}
