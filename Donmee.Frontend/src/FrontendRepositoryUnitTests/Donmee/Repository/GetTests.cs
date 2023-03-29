using Shouldly;

namespace FrontendRepositoryUnitTests.Donmee.Repository
{
    public class GetTests
    {
        [Fact]
        public async Task GetUsers()
        {
            // Arrange
            var repository = DonmeeRepositoryFactory<User>.Create();

            // Act
            var result = await repository.GetAll();

            // Assert
            result.ShouldBeOfType<List<User>>();
            result.Count().ShouldBe(3);
        }

        [Fact]        
        public async Task GetAllTransactionByUserId()
        {
            // Arrange
            var repository = DonmeeRepositoryFactory<Transaction>.Create();

            // Act

            var result = await repository.GetAll(tr =>
                tr.UserId == DonmeeRepositoryFactory<Transaction>.UserId_1);

            // Assert
            result.ShouldBeOfType<List<Transaction>>();
            result.Count().ShouldBe(3);
        }

        [Fact]
        public async Task GetWishById()
        {
            // Arrange
            var wishRepo = DonmeeRepositoryFactory<Wish>.Create();
            var wish_1 = DonmeeRepositoryFactory<Wish>.Wish_1;

            // Act
            var result = await wishRepo.Get(wish => wish.Id == wish_1);

            //Assert
            result.ShouldBeOfType<Wish>();
            result.Name.ShouldBe("Телефон");
        }

    }
}
