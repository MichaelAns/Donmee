using Frontend.Persistance.EntityConfigurations;
using Frontend.Persistance.Models;
using Microsoft.EntityFrameworkCore;

namespace Frontend.Persistance
{
    public class DonmeeDbContext : DbContext
    {
        public DonmeeDbContext(DbContextOptions options)
            : base(options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            FillContext(this);
            /*if (Database.EnsureCreated())
            {
                FillContext(this);
            }*/
            //Database.EnsureCreated();
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

        Guid UserId_1 = Guid.NewGuid();
        Guid UserId_2 = Guid.NewGuid();
        Guid UserId_3 = Guid.NewGuid();

        Guid Transaction_1 = Guid.NewGuid();
        Guid Transaction_2 = Guid.NewGuid();
        Guid Transaction_3 = Guid.NewGuid();

        Guid Wish_1 = Guid.NewGuid();
        Guid Wish_2 = Guid.NewGuid();
        Guid Wish_3 = Guid.NewGuid();
        private void FillContext(DonmeeDbContext dbContext)
        {

            User user_1 = new User
            {
                Id = UserId_1,
                Name = "Антон",
                SecondName = "Фикалис",
                Email = "fikalis@gmail.com",
                Password = "ssssssssss",
                Phone = "+79002281488"
            };
            User user_2 = new User
            {
                Id = UserId_2,
                Name = "Валерий",
                SecondName = "Жмышенко",
                Email = "zhma@gmail.com",
                Password = "sssssssss",
                Phone = "+79052281488"
            };
            User user_3 = new User
            {
                Id = UserId_3,
                Name = "Денис",
                SecondName = "Сухачев",
                Email = "denchik@gmail.com",
                Password = "sssssssss",
                Phone = "+79002281488"
            };

            Wish wish_1 = new Wish
            {
                Id = Wish_1,
                Name = "Телефон",
                Description = "Новый телефон",
                CurrentAmount = 100,
                EndDate = new DateTime(2023, 12, 25),
                WishType = Frontend.Persistance.Models.Enums.WishType.Common,
                Goal = 10000
            };
            Wish wish_2 = new Wish
            {
                Id = Wish_2,
                Name = "Ноутбук",
                Description = "Новый ноутбук",
                CurrentAmount = 100,
                EndDate = new DateTime(2023, 12, 25),
                WishType = Frontend.Persistance.Models.Enums.WishType.Common,
                Goal = 10000
            };
            Wish wish_3 = new Wish
            {
                Id = Wish_3,
                Name = "Энергетик Black Monster",
                CurrentAmount = 50,
                EndDate = new DateTime(2023, 12, 25),
                WishType = Frontend.Persistance.Models.Enums.WishType.Blitz,
                Goal = 100
            };

            dbContext.Set<Transaction>().AddRange(
                new Transaction
                {
                    Id = Transaction_1,
                    Count = 100,
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Replenishment,
                    User = user_1,
                    Wish = null
                },
                new Transaction
                {
                    Id = Transaction_2,
                    Count = 100,
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Replenishment,
                    //UserId = UserId_2,
                    User = user_2,
                    Wish = null
                },
                new Transaction
                {
                    Id = Transaction_3,
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Creating,
                    //UserId = UserId_1,
                    User = user_1,
                    //WishId = Wish_1,
                    Wish = wish_1,
                },
                new Transaction
                {
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Creating,
                    //UserId = UserId_2,
                    User = user_2,
                    //WishId = Wish_1,
                    Wish = wish_1
                },
                new Transaction
                {
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Creating,
                    //UserId = UserId_3,
                    User = user_3,
                    //WishId = Wish_3,
                    Wish = wish_3
                },
                new Transaction
                {
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Donate,
                    //UserId = UserId_1,
                    User = user_1,
                    //WishId = Wish_2,
                    Wish = wish_2,
                    Count = 100
                },
                new Transaction
                {
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Donate,
                    //UserId = UserId_2,
                    User = user_2,
                    //WishId = Wish_3,
                    Wish = wish_3,
                    Count = 50
                },
                new Transaction
                {
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Donate,
                    //UserId = UserId_3,
                    User = user_3,
                    //WishId = Wish_1,
                    Wish = wish_3,
                    Count = 100
                });
            dbContext.SaveChanges();
        }
    }
}

