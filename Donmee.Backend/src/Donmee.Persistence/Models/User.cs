using Microsoft.AspNetCore.Identity;

namespace Donmee.Persistence.Models
{
    /// <summary>
    /// Пользователь в базе данных
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Баланс
        /// </summary>
        public double Balance { get; set; } = 0;

        public virtual IEnumerable<Transaction>? Transactions { get; set; }
    }
}
