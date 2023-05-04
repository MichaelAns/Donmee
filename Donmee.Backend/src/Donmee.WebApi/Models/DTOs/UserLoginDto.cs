using System.ComponentModel.DataAnnotations;

namespace Donmee.WebApi.Models.DTOs
{
    public class UserLoginDto
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
