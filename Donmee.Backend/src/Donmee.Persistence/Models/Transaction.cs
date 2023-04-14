namespace Donmee.Persistence.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Count { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid? WishId { get; set; }
        public virtual Wish? Wish { get; set; }
    }
}
