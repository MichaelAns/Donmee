using Frontend.Persistance.Models.Enums;

namespace Frontend.Persistance.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }        
        public TransactionType TransactionType { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }

        public virtual User User { get; set; }
        public virtual Wish? Wish { get; set; }
    }
}
