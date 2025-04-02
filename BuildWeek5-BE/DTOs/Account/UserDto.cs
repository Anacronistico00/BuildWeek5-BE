using System.ComponentModel.DataAnnotations;

namespace BuildWeek5_BE.DTOs.Account
{
    public class UserDto
    {
  
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }
    }
}
