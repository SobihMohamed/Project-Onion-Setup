using E_commerce.Domain.Contracts;

using Microsoft.AspNetCore.Identity;

namespace E_commerce.Domain.Models.User
{
    public class ApplicationUser : IdentityUser, IEntity<string>
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
