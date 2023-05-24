using Donmee.DataServices.Identity;
using Donmee.DataServices.Wish;
using Donmee.Domain.DTOs;
using Shouldly;

namespace Donmee.UnitTests.ControllerTests
{
    /// <summary>
    /// Тестирование контроллера желаний
    /// </summary>
    public class WishTests
    {
        [Fact]
        public async Task WishTest()
        {
            // Arrange
            Guid id = Guid.Parse("6F0E85F5-50D9-4E4B-AA73-6454815D6F1A");
            UserLoginDto login = new UserLoginDto
            {
                Email = "mi035@mail.ru",
                Password = "password"
            };

            // Act
            var response = await new IdentityService().Identity(login);
            var token = response.Token;
            var wish = await new WishService().GetWishAsync(id, token);

            // Assert
            wish.ShouldNotBeNull();
            
        }

        [Fact]
        public async Task MyWishesTest()
        {
            // Arrange
            UserLoginDto login = new UserLoginDto
            {
                Email = "mi035@mail.ru",
                Password = "password"
            };

            // Act
            var response = await new IdentityService().Identity(login);
            var token = response.Token;
            var id = response.UserId;
            var wishes = await new WishService().GetMyWishesAsync(id, Domain.Enums.WishStatus.Active, token);

            // Assert
            wishes.ShouldNotBeNull();
        }

        [Fact]
        public async Task WishesTest()
        {
            // Arrange
            UserLoginDto login = new UserLoginDto
            {
                Email = "mi035@mail.ru",
                Password = "password"
            };

            // Act
            var response = await new IdentityService().Identity(login);
            var token = response.Token;
            var id = response.UserId;
            var wishes = await new WishService().GetWishesAsync(id, Domain.Enums.WishType.Common, token);

            // Assert
            wishes.ShouldNotBeNull();
        }
    }
}
