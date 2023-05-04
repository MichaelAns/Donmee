using System.ComponentModel.DataAnnotations;

namespace Donmee.WebApi.Models.DTOs
{
    /// <summary>
    /// Данные пользователя для регистрации
    /// </summary>
    public class UserRegistrationDto
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия 
        /// </summary>
        [Required]
        public string SecondName { get; set; }

        /// <summary>
        /// Номер телефона 
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// Хэш-код пароля
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Элеткронная почта
        /// </summary>
        [Required]
        public string Email { get; set; }
    }
}
