using Microsoft.AspNetCore.Identity;

namespace BuildWeek5_BE.Models.Auth
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
