using Frontend.Persistance.Models.Enums;

namespace Donmee.Client.Services.Wish
{
    public interface IWishService
    {
        /// <summary>
        /// Get wishes of other users
        /// </summary>
        /// <param name="userId">Requesting user's id</param>
        /// <returns>Wihes enumerable</returns>
        public Task<IEnumerable<Frontend.Persistance.Models.Wish>> GetWishesAsync(Guid userId);

        /// <summary>
        /// Get requesting user's wishes
        /// </summary>
        /// <param name="userId">Requesting user's id</param>
        /// <param name="wishStatus">Wish status (active / completed)</param>
        /// <returns>Requesting user's wishes enumerable</returns>
        public Task<IEnumerable<Frontend.Persistance.Models.Wish>> GetWishesAsync(Guid userId, WishStatus wishStatus);

        /// <summary>
        /// Get details about a requested wish
        /// </summary>
        /// <param name="id">Requested wish id</param>
        /// <returns>Wish</returns>
        public Task<Frontend.Persistance.Models.Wish> GetWishAsync(Guid id);
    }
}
