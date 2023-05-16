using Microsoft.AspNetCore.Identity;

namespace Donmee.Persistence.Models
{
    public class User : IdentityUser
    {
        public string SecondName { get; set; }
        public double Balance { get; set; } = 0;
        // public double Bonus { get; set; }

        public virtual IEnumerable<Transaction>? Transactions { get; set; }
    }
}
