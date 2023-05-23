using Donmee.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Donmee.Persistence
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class DonmeeDbContext : IdentityDbContext<User>
    {
        
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

        /// <summary>
        /// Применение конфигураций
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new WishConfiguration());
            builder.ApplyConfiguration(new TransactionConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
