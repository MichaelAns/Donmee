using Frontend.Persistance.EntityConfigurations;
using Frontend.Persistance.Models;

namespace Frontend.Persistance
{
    public class DonmeeDbContext : DbContext
    {
        public DonmeeDbContext(DbContextOptions options)
            : base(options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
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

