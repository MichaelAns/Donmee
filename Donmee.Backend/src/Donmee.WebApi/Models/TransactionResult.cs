namespace Donmee.WebApi.Models
{
    /// <summary>
    /// Результат выполнения транзакции
    /// </summary>
    public class TransactionResult
    {
        /// <summary>
        /// Результат транзакции <br/>
        /// true - если транзакция прошла успешно, false - иначе
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// Список ошибок
        /// </summary>
        public List<string> Errors { get; set; }
    }
}
