using Donmee.Domain.Enums;

namespace Donmee.DataServices.Wish
{
    //C:\Users\Borov\source\repos\Donmee\Donmee.Frontend\src\Donmee.DataServices\Donmee.DataServices.csproj
    public interface IWishService
    {
        /// <summary>
        /// Get other users wishes depending on the type
        /// </summary>
        /// <param name="userId">Requesting user's id</param>
        /// <returns>Wihes enumerable</returns>
        public Task<IEnumerable<Donmee.Domain.Wish>> GetWishesAsync(Guid userId, WishType type);

        /// <summary>
        /// Get requesting user's wishes
        /// </summary>
        /// <param name="userId">Requesting user's id</param>
        /// <param name="wishStatus">Wish status (active / completed)</param>
        /// <returns>Requesting user's wishes enumerable</returns>
        public Task<IEnumerable<Donmee.Domain.Wish>> GetWishesAsync(Guid userId, WishStatus wishStatus);

        /// <summary>
        /// Get details about a requested wish
        /// </summary>
        /// <param name="id">Requested wish id</param>
        /// <returns>Wish</returns>
        public Task<Donmee.Domain.Wish> GetWishAsync(Guid id);
    }
}
