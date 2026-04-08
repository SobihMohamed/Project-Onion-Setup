using E_commerce.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftBridge.Domain.Models
{
    public class Review: BaseEntity<Guid>
    {
        public Guid RequestId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProviderId { get; set; }
        public Guid ServiceId { get; set; }
        public byte Rating { get; set; }
        public string? Comment { get; set; } = string.Empty;
        public virtual ServiceRequest ServiceRequest { get; set; } = null!;
        public virtual Client Client { get; set; } = null!;
        public Provider Provider { get; set; } = null!;
    }
}
