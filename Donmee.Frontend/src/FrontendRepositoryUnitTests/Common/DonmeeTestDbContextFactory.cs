using Frontend.Persistance;
using Microsoft.EntityFrameworkCore.Design;

namespace FrontendRepositoryUnitTests.Common
{
    internal class DonmeeTestDbContextFactory : IDesignTimeDbContextFactory<DonmeeDbContext>
    {
        public DonmeeDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DonmeeDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            return new DonmeeDbContext(optionsBuilder.Options);
        }
    }
}
