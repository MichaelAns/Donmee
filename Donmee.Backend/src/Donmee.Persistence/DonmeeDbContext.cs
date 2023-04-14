using Donmee.Persistence.EntityConfigurations;

namespace Donmee.Persistence
{
    public class DonmeeDbContext : DbContext
    {
        public DonmeeDbContext(DbContextOptions options) 
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Wish> Wish { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new WishConfiguration());
            builder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}
