using Donmee.Domain.DTOs;
using Donmee.Domain.RequestResults;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Donmee.DataServices.Identity
{
    public class IdentityService : IIdentityService
    {
        public async Task<AuthResult> Identity(UserLoginDto user)
        {
            using (var client = new HttpClient())
            {
                string endPoint = "https://localhost:7287/api/Auth/Login";
                var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endPoint, content);
                var authResult = (AuthResult)await response.Content.ReadFromJsonAsync(typeof(AuthResult));
                return authResult;
            }
        }

        public async Task<AuthResult> Validate(string token)
        {
            using (var client = new HttpClient())
            {
                string endPoint = $"https://localhost:7287/api/Auth/Validate?token={token}";
                var response = await client.GetAsync(endPoint);
                var authResult = (AuthResult)await response.Content.ReadFromJsonAsync(typeof(AuthResult));
                return authResult;
            }
        }

        public async Task<AuthResult> SignUp(UserRegistrationDto user)
        {
            using (var client = new HttpClient())
            {
                string endPoint = "https://localhost:7287/api/Auth/Register";
                var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endPoint, content);
                var authResult = (AuthResult)await response.Content.ReadFromJsonAsync(typeof(AuthResult));
                return authResult;
            }
        }
    }
}
