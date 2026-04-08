using E_commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftBridge.Domain.Models
{

    //+ServiceRequest? Request
    public class Message: BaseEntity<Guid>
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public Guid? RequestId { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool Isread { get; set; } = false;
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public virtual ApplicationUser Sender { get; set; } = null!;
        public virtual ApplicationUser Receiver { get; set; } = null!;
        public virtual ServiceRequest ServiceRequest { get; set; } = null!;
    }
}
