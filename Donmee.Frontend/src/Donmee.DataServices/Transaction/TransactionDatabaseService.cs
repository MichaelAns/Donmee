namespace Donmee.DataServices.Transaction
{
    public class TransactionDatabaseService : ITransactionService
    {
        public Task CreatingTransaction(Guid userId, Domain.Wish wish)
        {
            throw new NotImplementedException();
        }

        public Task DonateTransaction(Guid userId, Domain.Wish wish, int money)
        {
            throw new NotImplementedException();
        }

        public Task ReplenishmentTransaction(Guid userId, int money)
        {
            throw new NotImplementedException();
        }
    }
}
