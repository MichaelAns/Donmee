using Frontend.Persistance;
using Frontend.Persistance.Models;
using Shouldly;

namespace FrontendRepositoryUnitTests.Donmee.Database
{
    public class CreateDbContextTests
    {
        [Fact]
        public async Task CreateRealDbContext()
        {
            // Arrange
            await DonmeeTestsFactory.InitDatabase();
            
            // Act
            var dbContext = new DonmeeDbContextFactory().CreateDbContext(DonmeeTestsFactory.Args);
            var users = await dbContext.User.ToListAsync();
            var wishes = await dbContext.Wish.ToListAsync();
            var transaction = await dbContext.Transaction.ToListAsync();

            // Assert
            users.ShouldNotBeNull();
            //users.Count().ShouldBe(3);

            wishes.ShouldNotBeNull();
            //wishes.Count().ShouldBe(3);

            transaction.ShouldNotBeNull();
            //transaction.Count().ShouldBe(8);
        }
    }

    
}
