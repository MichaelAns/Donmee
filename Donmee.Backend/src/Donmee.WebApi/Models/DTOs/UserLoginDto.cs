using System.ComponentModel.DataAnnotations;

namespace Donmee.WebApi.Models.DTOs
{
    /// <summary>
    /// Данные пользователя для входа
    /// </summary>
    public class UserLoginDto
    {
        /// <summary>
        /// Пароль
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
