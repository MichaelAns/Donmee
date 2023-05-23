using Donmee.Domain;
using Donmee.Domain.RequestResults;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Donmee.DataServices.Transaction
{
    public class TransactionService : ITransactionService
    {
        public async Task<TransactionResult> CreatingTransaction(
            string userId, 
            Domain.Wish wish,
            string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string endPoint = $"https://localhost:7287/api/Transaction/Creating?userId={userId}";
                var content = new StringContent(JsonConvert.SerializeObject(wish), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endPoint, content);
                var authResult = (TransactionResult)await response.Content.ReadFromJsonAsync(typeof(TransactionResult));
                return authResult;
            }
        }

        public async Task<TransactionResult> DonateTransaction(
            string userId, 
            Guid wishId, 
            int money,
            string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string endPoint = $"https://localhost:7287/api/Transaction/Donate?userId={userId}&wishId={wishId}&money={money}";

                var response = await client.PostAsync(endPoint, null);
                var authResult = (TransactionResult)await response.Content.ReadFromJsonAsync(typeof(TransactionResult));
                return authResult;
            }
        }

        public async Task<TransactionResult> ReplenishmentTransaction(
            string userId, 
            int money,
            string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string endPoint = $"https://localhost:7287/api/Transaction/Replenishment?userId={userId}&money={money}";

                var response = await client.PostAsync(endPoint, null);
                var authResult = (TransactionResult)await response.Content.ReadFromJsonAsync(typeof(TransactionResult));
                return authResult;
            }
        }
    }
}
