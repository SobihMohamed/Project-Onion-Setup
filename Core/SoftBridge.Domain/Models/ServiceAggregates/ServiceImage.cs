<<<<<<< HEAD
﻿using SoftBridge.Domain.Models.Shared;
=======
﻿
>>>>>>> 2d8a7662502cc08f2d4a72432349b54d9f85f25a

using SoftBridge.Domain.Models.Shared;

namespace SoftBridge.Domain.Models.ServiceAggregates
{
    public class ServiceImage: BaseEntity<Guid>
    {
        public Guid ServiceId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPortfolio { get; set; } = false;
        public int DisplayOrder { get; set; }
        public virtual Service Service { get; set; } = null!;
    }
}
