namespace Donmee.Persistence.Models
{
    /// <summary>
    /// Желание в базе данных
    /// </summary>
    public class Wish
    {
        /// <summary>
        /// ID пользователя
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название желания
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание желания
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Путь до картинки (картинки встроены в клиентское приложение)
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Цель
        /// </summary>
        public int Goal { get; set; }

        /// <summary>
        /// Текущая сумма (изаначально = 0)
        /// </summary>
        public int CurrentAmount { get; set; } = 0;

        /// <summary>
        /// Тип желание (обычное или блиц)
        /// </summary>
        public WishType WishType { get; set; }

        /// <summary>
        /// Статус желание (активное или завершённое, изначально активное)
        /// </summary>
        public WishStatus WishStatus { get; set; } = WishStatus.Active;

        /// <summary>
        /// Дата завершения желание (4 дня)
        /// </summary>
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(4);


        public virtual IEnumerable<Transaction>? Transactions { get; set; }
    }
}
