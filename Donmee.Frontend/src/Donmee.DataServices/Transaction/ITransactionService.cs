using Donmee.Domain.RequestResults;

namespace Donmee.DataServices.Transaction
{
    public interface ITransactionService
    {
        public Task<TransactionResult> ReplenishmentTransaction(string userId, int money);
        public Task<TransactionResult> CreatingTransaction(string userId, Donmee.Domain.Wish wish);
        public Task<TransactionResult> DonateTransaction(string userId, Guid wishId, int money);
    }
}
