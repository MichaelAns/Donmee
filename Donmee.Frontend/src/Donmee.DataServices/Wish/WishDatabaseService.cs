using Frontend.Persistance;
using Frontend.Persistance.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Donmee.DataServices.Wish
{
    public class WishDatabaseService : IWishService
    {
        public async Task<Frontend.Persistance.Models.Wish> GetWishAsync(Guid id)
        {
            using (var dbContext = new DonmeeDbContextFactory().CreateDbContext())
            {
                // All user's wishes
                var wishes = await dbContext.Wish
                    .FirstOrDefaultAsync(wish => wish.Id == id);
                return wishes;
            }
        }

        public async Task<IEnumerable<Frontend.Persistance.Models.Wish>> GetWishesAsync(Guid userId)
        {
            using (var dbContext = new DonmeeDbContextFactory().CreateDbContext())
            {
                // All wishes of other users
                var wishes = await dbContext.Transaction
                    .Where(trans =>
                        trans.UserId != userId &&
                        trans.TransactionType == TransactionType.Creating)
                    .Select(tr => tr.Wish)
                    .Where(wish => wish.WishStatus == WishStatus.Active)
                    .ToListAsync();
                return wishes;
            }
        }

        public async Task<IEnumerable<Frontend.Persistance.Models.Wish>> GetWishesAsync(Guid userId, WishStatus wishStatus)
        {
            using (var dbContext = new DonmeeDbContextFactory().CreateDbContext())
            {
                // All user's wishes
                var wishes = await dbContext.Transaction
                    .Where(trans =>
                        trans.UserId == userId &&
                        trans.WishId != null &&
                        trans.TransactionType == Frontend.Persistance.Models.Enums.TransactionType.Creating)
                    .Select(tr => tr.Wish)
                    .Where(wish => wish.WishStatus == wishStatus)
                    .ToListAsync();
                return wishes;
            }
        }
    }
}
