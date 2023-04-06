using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace Frontend.Persistance
{
    public class DonmeeDbContextFactory : IDesignTimeDbContextFactory<DonmeeDbContext>
    {
        public DonmeeDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DonmeeDbContext>();
            string testPath = @"C:\Users\Borov\source\repos\Donmee\Donmee.Frontend\src\newdatabase.db";
            optionsBuilder.UseSqlite($"Filename={testPath}");
            return new DonmeeDbContext(optionsBuilder.Options);
        }
    }
}
