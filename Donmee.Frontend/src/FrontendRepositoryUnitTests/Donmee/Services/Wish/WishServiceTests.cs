using Donmee.DataServices.Wish;
using Frontend.Persistance;
using Shouldly;

namespace FrontendRepositoryUnitTests.Donmee.Services.Wish
{
    public class WishServiceTests
    {
        [Fact]
        public async Task GetWishes()
        {
            // Arrange
            await DonmeeTestsFactory.InitDatabase();

            // Act
            var service = new WishDatabaseService();
            var wishes = await service.GetWishesAsync(DonmeeTestsFactory.UserId_1);

            // Assert
            Assert.NotNull(wishes);
            wishes.Count().ShouldBe(2);            
        }

        [Fact]
        public async Task GetActiveWishesByUserId()
        {
            // Arrange
            await DonmeeTestsFactory.InitDatabase();

            // Act
            var service = new WishDatabaseService();
            var activeWishes = await service.GetWishesAsync(
                DonmeeTestsFactory.UserId_1,
                Frontend.Persistance.Models.Enums.WishStatus.Active);

            // Assert
            Assert.NotNull(activeWishes);
            activeWishes.Count().ShouldBe(1);
        }

        [Fact]
        public async Task GetCompletedWishesByUserId()
        {
            // Arrange
            await DonmeeTestsFactory.InitDatabase();

            // Act
            var service = new WishDatabaseService();
            var completedeWishes = await service.GetWishesAsync(
                DonmeeTestsFactory.UserId_1,
                Frontend.Persistance.Models.Enums.WishStatus.Completed);

            // Assert
            completedeWishes.Count().ShouldBe(0);            
        }

        [Fact]
        public async Task GetWishDetails()
        {
            // Arrange
            await DonmeeTestsFactory.InitDatabase();

            // Act
            var service = new WishDatabaseService();
            var wish = await service.GetWishAsync(DonmeeTestsFactory.Wish_1);

            // Assert
            wish.ShouldNotBeNull();
            wish.Name.ShouldBe("Телефон");
        }
    }
}
