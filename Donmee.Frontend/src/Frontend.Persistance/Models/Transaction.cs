using Frontend.Persistance.Models.Enums;

namespace Frontend.Persistance.Models
{
    internal class Transaction
    {
        public Guid Id { get; set; }        
        public TransactionType TransactionType { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
