using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace Frontend.Persistance
{
    public class DonmeeDbContextFactory : IDesignTimeDbContextFactory<DonmeeDbContext>
    {
        public DonmeeDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DonmeeDbContext>();
            string testPath = Path.Combine(FileSystem.AppDataDirectory, "database.db");
            optionsBuilder.UseSqlite($"Filename={testPath}");
            //optionsBuilder.UseNpgsql(testPath);
            return new DonmeeDbContext(optionsBuilder.Options);
        }
    }
}
