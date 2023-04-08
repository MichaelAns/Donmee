using Microsoft.EntityFrameworkCore.Design;

namespace Frontend.Persistance
{
    public class DonmeeDbContextFactory : IDesignTimeDbContextFactory<DonmeeDbContext>
    {
        public DonmeeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DonmeeDbContext>();
            string testPath = $@"{args[0]}\database.db";
            //string testPath = Path.Combine(args[0], "\\database.db");
            optionsBuilder.UseSqlite($"Filename = {testPath}");
            return new DonmeeDbContext(optionsBuilder.Options);
            
        }
    }
}
