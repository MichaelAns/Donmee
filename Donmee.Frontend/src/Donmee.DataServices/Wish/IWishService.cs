using Donmee.Domain.Enums;

namespace Donmee.DataServices.Wish
{
    
    public interface IWishService
    {
        public Task<IEnumerable<Donmee.Domain.Wish>> GetWishesAsync(string userId, WishType type);

        public Task<IEnumerable<Donmee.Domain.Wish>> GetWishesAsync(string userId, WishStatus wishStatus);

        public Task<Donmee.Domain.Wish> GetWishAsync(Guid wishId);
    }
}
