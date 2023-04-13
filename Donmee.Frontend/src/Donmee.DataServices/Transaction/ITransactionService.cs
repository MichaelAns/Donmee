namespace Donmee.DataServices.Transaction
{
    public interface ITransactionService
    {
        public Task ReplenishmentTransaction(Guid userId, int money);
        public Task CreatingTransaction(Guid userId, Frontend.Persistance.Models.Wish wish);
        public Task DonateTransaction(Guid userId, Frontend.Persistance.Models.Wish wish, int money);
    }
}
