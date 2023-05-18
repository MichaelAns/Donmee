using Donmee.Domain.Enums;

namespace Donmee.DataServices.Wish
{
    public class WishDatabaseService : IWishService
    {
        public Task<Domain.Wish> GetWishAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Wish>> GetWishesAsync(Guid userId, WishType type)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Wish>> GetWishesAsync(Guid userId, WishStatus wishStatus)
        {
            throw new NotImplementedException();
        }
    }
}
