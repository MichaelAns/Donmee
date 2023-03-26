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
            //result.ShouldBeOfType<IEnumerable<User>>();
            result.Count().ShouldBe(3);
        }
    }
}
