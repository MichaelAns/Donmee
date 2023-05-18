namespace Donmee.DataServices.Transaction
{
    public interface ITransactionService
    {
        public Task ReplenishmentTransaction(Guid userId, int money);
        public Task CreatingTransaction(Guid userId, Donmee.Domain.Wish wish);
        public Task DonateTransaction(Guid userId, Donmee.Domain.Wish wish, int money);
    }
}
