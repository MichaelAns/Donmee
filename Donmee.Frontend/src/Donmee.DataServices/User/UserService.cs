using Donmee.Domain.RequestResults;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Donmee.DataServices.User
{
    public class UserService : IUserService
    {
        public async Task<Domain.User> GetUser(string userId, string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string endPoint = $"https://localhost:7287/api/Transaction/User?userId={userId}";

                var response = await client.GetAsync(endPoint);
                var user = (Domain.User)await response.Content.ReadFromJsonAsync(typeof(Domain.User));
                return user;
            }
        }
    }
}
