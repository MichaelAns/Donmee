using Donmee.Domain.RequestResults;

namespace Donmee.DataServices.Transaction
{
    /// <summary>
    /// Транзакции пользователя
    /// </summary>
    public interface ITransactionService
    {
        public Task<TransactionResult> ReplenishmentTransaction(string userId, int money, string token);
        public Task<TransactionResult> CreatingTransaction(string userId, Donmee.Domain.Wish wish, string token);
        public Task<TransactionResult> DonateTransaction(string userId, Guid wishId, int money, string token);
    }
}
