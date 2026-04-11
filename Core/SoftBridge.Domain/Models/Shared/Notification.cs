using SoftBridge.Domain.Models.User;
using System;
<<<<<<< HEAD
using SoftBridge.Domain.Models.Shared;
using SoftBridge.Domain.Models.User;
=======

>>>>>>> 2d8a7662502cc08f2d4a72432349b54d9f85f25a

namespace SoftBridge.Domain.Models.Shared;

public class Notification : BaseEntity<Guid>
{
    public string UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; } = false;
    public Guid? ReferenceId { get; set; }

    // Navigation property
    public ApplicationUser User { get; set; } = null!;
}
