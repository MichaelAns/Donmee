using Frontend.Persistance.Models;

namespace Donmee.DataServices.Transaction
{
    public class TransactionDatabaseService : ITransactionService
    {
        public TransactionDatabaseService(string[] args)
        {
            Args = args;
        }

        private string[] Args;

        public async Task CreatingTransaction(Guid userId, Frontend.Persistance.Models.Wish wish)
        {
            using (var dbContext = new DonmeeDbContextFactory().CreateDbContext(Args))
            {
                await dbContext.Transaction.AddAsync(new Frontend.Persistance.Models.Transaction
                {
                    Count = 1,
                    TransactionType = TransactionType.Creating,
                    UserId = userId,
                    Wish = wish
                });
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DonateTransaction(Guid userId, Frontend.Persistance.Models.Wish wish, int money)
        {
            using (var dbContext = new DonmeeDbContextFactory().CreateDbContext(Args))
            {
                var balance = dbContext.User.FirstOrDefaultAsync(user => user.Id == userId).Result.Balance;
                if (money < balance)
                {
                    throw new Exception("Insufficient funds");
                }

                await dbContext.Transaction.AddAsync(new Frontend.Persistance.Models.Transaction
                {
                    Count = money,
                    TransactionType = TransactionType.Donate,
                    WishId = wish.Id,
                    UserId = userId
                });

                var changingUser = dbContext.User.Update(dbContext.User.FirstOrDefaultAsync(user => user.Id == userId).Result);
                changingUser.Entity.Balance -= money;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task ReplenishmentTransaction(Guid userId, int money)
        {
            using (var dbContext = new DonmeeDbContextFactory().CreateDbContext(Args))
            {
                await dbContext.Transaction.AddAsync(new Frontend.Persistance.Models.Transaction
                {
                    Count = money,
                    TransactionType = TransactionType.Replenishment,
                    UserId = userId
                });

                var changingUser = dbContext.User.Update(dbContext.User.FirstOrDefaultAsync(user => user.Id == userId).Result);
                changingUser.Entity.Balance += money;

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
