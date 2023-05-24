using Donmee.Domain.DTOs;
using Donmee.Domain.RequestResults;
using Donmee.UnitTests.Common;
using Newtonsoft.Json;
using Shouldly;
using System.Net.Http.Json;
using System.Text;

namespace Donmee.UnitTests.ControllerTests
{
    /// <summary>
    /// Тестирование регистрации и авторизации
    /// </summary>
    public class AuthTests
    {
        [Fact]
        public async Task Register()
        {
            // Arrange
            await DonmeeTestsFactory.UpdateDatabase();
            var user = new UserRegistrationDto()
            {
                Name = "Mikhail",
                SecondName = "Shukin",
                Email = "mi035@mail.ru",
                Password = "password",
                Phone = "89209238969"
            };

            string endPoint = "https://localhost:7287/api/Auth/Register";
            var httpClient = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            // Act
            var response = await httpClient.PostAsync(endPoint, content);
            var authResult = (AuthResult)await response.Content.ReadFromJsonAsync(typeof(AuthResult));

            // Assert
            authResult.Result.ShouldBeTrue();
            authResult.Errors.ShouldBeNull();

        }

        [Fact]
        public async Task Login()
        {
            string endPoint = "https://localhost:7287/api/Auth/Login";
            var user = new UserLoginDto()
            {
                Email = "mi035@mail.ru",
                Password = "password"
            };

            var httpClient = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"),
                RequestUri = new Uri(endPoint)
            };

            // Act
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);

            var authResult = (AuthResult)await response.Content.ReadFromJsonAsync(typeof(AuthResult));

            // Assert
            authResult.Result.ShouldBeTrue();
            authResult.Token.ShouldNotBeNullOrEmpty();
            authResult.Errors.ShouldBeNull();
        }
    }
}
