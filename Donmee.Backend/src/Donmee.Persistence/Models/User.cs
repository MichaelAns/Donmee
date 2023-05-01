namespace Donmee.Persistence.Models
{
    public class User
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; } = 0;
        // public double Bonus { get; set; }

        public virtual IEnumerable<Transaction>? Transactions { get; set; }
    }
}
