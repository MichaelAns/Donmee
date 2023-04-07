using Donmee.DataServices.Identity;
using Shouldly;

namespace FrontendRepositoryUnitTests.Donmee.Services.Identity
{
    public class IdentityServiceTests
    {
        [Fact]
        public async Task Identity()
        {
            // Arrange
            await DonmeeTestsFactory.InitDatabase();

            // Act
            var service = new IdentityDatabaseService(DonmeeTestsFactory.Args);
            var id = await service.Identity("fikalis@gmail.com", "ssssssssss");

            // Assert
            id.ShouldNotBeNull();
            Guid.Parse(id).ShouldBe(DonmeeTestsFactory.UserId_1);
        }
    }
}
