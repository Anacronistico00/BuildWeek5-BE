using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace BuildWeek5_BE.Models.Auth
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required DateOnly BirthDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
