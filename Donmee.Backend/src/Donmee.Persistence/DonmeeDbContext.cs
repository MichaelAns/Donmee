using Donmee.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Donmee.Persistence
{
    public class DonmeeDbContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        /// <param name="options"></param>
        public DonmeeDbContext(DbContextOptions options) 
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            Database.EnsureCreated();
        }

        /// <summary>
        /// Желания
        /// </summary>
        public DbSet<Wish> Wish { get; set; }

        /// <summary>
        /// Транзакции
        /// </summary>
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new WishConfiguration());
            builder.ApplyConfiguration(new TransactionConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
