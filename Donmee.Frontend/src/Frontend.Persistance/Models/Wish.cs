using Frontend.Persistance.Models.Enums;

namespace Frontend.Persistance.Models
{

    public class Wish
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Goal { get; set; }

        // Is this necessary?
        public int CurrentAmount { get; set; }
        public WishType WishType { get; set; }

        public DateTime EndDate { get; set; }

        public virtual IEnumerable<Transaction>? Transactions { get; set; }
    }
}
