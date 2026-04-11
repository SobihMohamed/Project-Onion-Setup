<<<<<<< HEAD
﻿using SoftBridge.Domain.Models.Shared;
using SoftBridge.Domain.Models.AccountAggregates;
=======
﻿using SoftBridge.Domain.Models.AccountAggregates;
using SoftBridge.Domain.Models.Shared;
>>>>>>> 2d8a7662502cc08f2d4a72432349b54d9f85f25a

namespace SoftBridge.Domain.Models.OrderAggregates
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
        public virtual SProvider Provider { get; set; } = null!;
    }
}
