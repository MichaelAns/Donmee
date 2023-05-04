using System.ComponentModel.DataAnnotations;

namespace Donmee.WebApi.Models.DTOs
{
    public class UserRegistrationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
