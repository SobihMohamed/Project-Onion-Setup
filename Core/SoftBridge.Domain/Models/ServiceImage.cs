using E_commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftBridge.Domain.Models
{
    public class ServiceImage: BaseEntity<Guid>
    {
        public Guid ServiceId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPortfolio { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Service Service { get; set; } = null!;
    }
}
