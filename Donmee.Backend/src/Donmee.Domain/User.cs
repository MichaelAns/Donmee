using System.ComponentModel.DataAnnotations;

namespace Donmee.Domain
{
    public class User
    {
        public Guid? Id { get; set; }
        
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

        [Required]
        public double Balance { get; set; }
    }
}
