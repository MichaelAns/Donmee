namespace Donmee.Persistence.Models
{
    /// <summary>
    /// Транзакция в базе данных
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// ID транзакции
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Тип (пополнение, создание, донат)
        /// </summary>
        public TransactionType TransactionType { get; set; }

        /// <summary>
        /// Дата и время совершения транзакции
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;

        /// <summary>
        /// Количество пополнения, создания или доната
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// ID пользователя
        /// </summary>
        public string UserId { get; set; }
        public virtual User User { get; set; }
        
        /// <summary>
        /// ID желания
        /// </summary>
        public Guid? WishId { get; set; }
        public virtual Wish? Wish { get; set; }
    }
}
