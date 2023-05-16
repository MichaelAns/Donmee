using Donmee.Persistence;
using Donmee.Persistence.Models;
using Donmee.Persistence.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BackEndUnitTests.Common
{
    public static class DonmeeTestsFactory
    {
        public static string UserId_1 = "6F0E85F5-50D9-4E4B-AA73-6454815D6F1A";
        public static string UserId_2 = Guid.NewGuid().ToString();
        public static string UserId_3 = Guid.NewGuid().ToString();

        public static Guid Transaction_1 = Guid.NewGuid();
        public static Guid Transaction_2 = Guid.NewGuid();
        public static Guid Transaction_3 = Guid.NewGuid();

        public static Guid Wish_1 = Guid.NewGuid();
        public static Guid Wish_2 = Guid.NewGuid();
        public static Guid Wish_3 = Guid.NewGuid();

        public static void AddRange(DonmeeDbContext dbContext)
        {
            User user_1 = new User
            {
                Id = UserId_1,
                UserName = "Антон",
                SecondName = "Фикалис",
                Email = "fikalis@gmail.com",
                PasswordHash = "ssssssssss",
                PhoneNumber = "+79002281488"
            };
            User user_2 = new User
            {
                Id = UserId_2,
                UserName = "Валерий",
                SecondName = "Жмышенко",
                Email = "zhma@gmail.com",
                PasswordHash = "sssssssss",
                PhoneNumber = "+79052281488"
            };
            User user_3 = new User
            {
                Id = UserId_3,
                UserName = "Денис",
                SecondName = "Сухачев",
                Email = "denchik@gmail.com",
                PasswordHash = "sssssssss",
                PhoneNumber = "+79002281488"
            };

            Wish wish_1 = new Wish
            {
                Id = Wish_1,
                Name = "Телефон",
                Description = "Новый телефон",
                CurrentAmount = 100,
                EndDate = new DateTime(2023, 12, 25),
                WishType = WishType.Common,
                Goal = 10000
            };
            Wish wish_2 = new Wish
            {
                Id = Wish_2,
                Name = "Ноутбук",
                Description = "Новый ноутбук",
                CurrentAmount = 100,
                EndDate = new DateTime(2023, 12, 25),
                WishType = WishType.Common,
                Goal = 10000
            };
            Wish wish_3 = new Wish
            {
                Id = Wish_3,
                Name = "Энергетик Black Monster",
                CurrentAmount = 50,
                EndDate = new DateTime(2023, 12, 25),
                WishType = WishType.Blitz,
                Goal = 100
            };

            dbContext.Set<Transaction>().AddRange(
                new Transaction
                {
                    Id = Transaction_1,
                    Count = 100,
                    TransactionType = TransactionType.Replenishment,
                    User = user_1,
                    Wish = null
                },
                new Transaction
                {
                    Id = Transaction_2,
                    Count = 100,
                    TransactionType = TransactionType.Replenishment,
                    User = user_2,
                    Wish = null
                },
                new Transaction
                {
                    Id = Transaction_3,
                    TransactionType = TransactionType.Creating,
                    User = user_1,
                    Wish = wish_1,
                },
                new Transaction
                {
                    TransactionType = TransactionType.Creating,
                    User = user_2,
                    Wish = wish_1
                },
                new Transaction
                {
                    TransactionType = TransactionType.Creating,
                    User = user_3,
                    Wish = wish_3
                },
                new Transaction
                {
                    TransactionType = TransactionType.Donate,
                    User = user_1,
                    Wish = wish_2,
                    Count = 100
                },
                new Transaction
                {
                    TransactionType = TransactionType.Donate,
                    User = user_2,
                    Wish = wish_3,
                    Count = 50
                },
                new Transaction
                {
                    TransactionType = TransactionType.Donate,
                    User = user_3,
                    Wish = wish_3,
                    Count = 100
                });
        }

        public static async Task<DonmeeDbContext> InitDatabase()
        {
            var options = new DbContextOptionsBuilder<DonmeeDbContext>()
                .UseNpgsql("Host=localhost;Port=5432;Database=DonmeeTest;Username=postgres;Password=qwertyfsy")
                .Options;

            var context = new DonmeeDbContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            AddRange(context);
            await context.SaveChangesAsync();

            return context;
        }
    }
}
