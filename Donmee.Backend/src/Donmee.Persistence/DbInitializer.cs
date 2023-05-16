namespace Donmee.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(DonmeeDbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }

    }
}
