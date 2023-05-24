using Donmee.Domain.Enums;

namespace Donmee.DataServices.Wish
{
    /// <summary>
    /// Желания пользователя
    /// </summary>
    public interface IWishService
    {
        public Task<IEnumerable<Donmee.Domain.Wish>> GetWishesAsync(string userId, WishType type, string token);

        public Task<IEnumerable<Donmee.Domain.Wish>> GetMyWishesAsync(string userId, WishStatus wishStatus, string token);

        public Task<Donmee.Domain.Wish> GetWishAsync(Guid wishId, string token);
    }
}
