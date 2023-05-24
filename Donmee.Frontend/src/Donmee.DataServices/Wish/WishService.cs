using Donmee.Domain.Enums;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Donmee.DataServices.Wish
{
    public class WishService : IWishService
    {
        public async Task<Domain.Wish> GetWishAsync(
            Guid wishId, 
            string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string endPoint = $"https://localhost:7287/api/Wish/Wish?id={wishId}";

                var response = await client.GetAsync(endPoint);
                var wish = (Domain.Wish)await response.Content.ReadFromJsonAsync(typeof(Domain.Wish));
                return wish;
            }
        }

        public async Task<IEnumerable<Domain.Wish>> GetWishesAsync(
            string userId, 
            WishType type, 
            string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string endPoint = $"https://localhost:7287/api/Wish/Wishes?userId={userId}&type={type}";

                var response = await client.GetAsync(endPoint);
                var wishes = (IEnumerable<Domain.Wish>)await response.Content.ReadFromJsonAsync(typeof(IEnumerable<Domain.Wish>));
                return wishes;
            }
        }

        public async Task<IEnumerable<Domain.Wish>> GetMyWishesAsync(
            string userId, 
            WishStatus wishStatus, 
            string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string endPoint = $"https://localhost:7287/api/Wish/MyWishes?userId={userId}&wishStatus={wishStatus}";

                var response = await client.GetAsync(endPoint);
                var wishes = (IEnumerable<Domain.Wish>)await response.Content.ReadFromJsonAsync(typeof(IEnumerable<Domain.Wish>));
                return wishes;
            }
        }
    }
}
