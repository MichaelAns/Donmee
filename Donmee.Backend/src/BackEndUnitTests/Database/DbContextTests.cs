using BackEndUnitTests.Common;
using Microsoft.EntityFrameworkCore;

namespace BackEndUnitTests.Database
{
    public class DbContextTests
    {
        [Fact]
        public async Task CreateRealDbContext()
        {
            // Arrange
            await DonmeeTestsFactory.InitDatabase();

            // Act
            var dbContext = await DonmeeTestsFactory.InitDatabase();
            var users = await dbContext.User.ToListAsync();
            var wishes = await dbContext.Wish.ToListAsync();
            var transaction = await dbContext.Transaction.ToListAsync();

            // Assert
            users.ShouldNotBeNull();
            users.Count().ShouldBe(3);

            wishes.ShouldNotBeNull();
            wishes.Count().ShouldBe(3);

            transaction.ShouldNotBeNull();
            transaction.Count().ShouldBe(8);
        }
    }
}
