using Frontend.Repository;

namespace FrontendRepositoryUnitTests.Common
{
    public class DonmeeRepositoryFactory<T>
        where T : class
    {
        public static Guid UserId_1 = Guid.NewGuid();
        public static Guid UserId_2 = Guid.NewGuid();
        public static Guid UserId_3 = Guid.NewGuid();

        public static Guid Transaction_1 = Guid.NewGuid();
        public static Guid Transaction_2 = Guid.NewGuid();
        public static Guid Transaction_3 = Guid.NewGuid();

        public static Guid Wish_1 = Guid.NewGuid();
        public static Guid Wish_2 = Guid.NewGuid();
        public static Guid Wish_3 = Guid.NewGuid();

        public static DonmeeRepository<T> Create()
        {
            var context = new DonmeeTestDbContextFactory().CreateDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            AddRange(context);
            context.SaveChanges();

            return new DonmeeRepository<T>(context);
        }

        private static void AddRange(DbContext dbContext)
        {
            dbContext.Set<User>().AddRange(
                new User
                {
                    Id = UserId_1,
                    Name = "Антон",
                    SecondName = "Фикалис",
                    Email = "fikalis@gmail.com",
                    Password = "ssssssssss",
                    Phone = "+79002281488"
                },
                new User
                {
                    Id = UserId_2,
                    Name = "Валерий",
                    SecondName = "Жмышенко",
                    Email = "zhma@gmail.com",
                    Password = "sssssssss",
                    Phone = "+79052281488"
                },
                new User
                {
                    Name = "Денис",
                    SecondName = "Сухачев",
                    Email = "denchik@gmail.com",
                    Password = "sssssssss",
                    Phone = "+79002281488"
                });

            dbContext.Set<Wish>().AddRange(
                new Wish
                {
                    Id = Wish_1,
                    Name = "Телефон",
                    Description = "Новый телефон",
                    CurrentAmount = 100,
                    EndDate = new DateTime(2023, 12, 25),
                    WishType = Frontend.Persistance.Models.Enums.WishType.Common,
                    Goal = 10000
                },
                new Wish
                {
                    Id = Wish_2,
                    Name = "Ноутбук",
                    Description = "Новый ноутбук",
                    CurrentAmount = 100,
                    EndDate = new DateTime(2023, 12, 25),
                    WishType = Frontend.Persistance.Models.Enums.WishType.Common,
                    Goal = 10000
                },
                new Wish
                {
                    Id = Wish_3,
                    Name = "Энергетик Black Monster",
                    CurrentAmount = 50,
                    EndDate = new DateTime(2023, 12, 25),
                    WishType = Frontend.Persistance.Models.Enums.WishType.Blitz,
                    Goal = 100
                });

            dbContext.Set<Transaction>().AddRange(
                new Transaction
                {
                    Id = Transaction_1,
                    Count = 100,
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Replenishment,
                    UserId = UserId_1,
                    User = dbContext.Set<User>().FirstOrDefault(user => user.Id == UserId_1),
                    Wish = null
                },
                new Transaction
                {
                    Id = Transaction_2,
                    Count = 100,
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Replenishment,
                    UserId = UserId_2,
                    User = dbContext.Set<User>().FirstOrDefault(user => user.Id == UserId_2),
                    Wish = null
                },
                new Transaction
                {
                    Id = Transaction_3,
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Creating,
                    UserId = UserId_1,
                    User = dbContext.Set<User>().FirstOrDefault(user => user.Id == UserId_1),
                    WishId = Wish_1,
                    Wish = dbContext.Set<Wish>().FirstOrDefault(wish => wish.Id == Wish_1),
                },
                new Transaction
                {
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Creating,
                    UserId = UserId_2,
                    User = dbContext.Set<User>().FirstOrDefault(user => user.Id == UserId_2),
                    WishId = Wish_1,
                    Wish = dbContext.Set<Wish>().FirstOrDefault(wish => wish.Id == Wish_1),
                },
                new Transaction
                {
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Creating,
                    UserId = UserId_3,
                    User = dbContext.Set<User>().FirstOrDefault(user => user.Id == UserId_3),
                    WishId = Wish_3,
                    Wish = dbContext.Set<Wish>().FirstOrDefault(wish => wish.Id == Wish_3),
                },
                new Transaction
                {
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Donate,
                    UserId = UserId_1,
                    User = dbContext.Set<User>().FirstOrDefault(user => user.Id == UserId_1),
                    WishId = Wish_2,
                    Wish = dbContext.Set<Wish>().FirstOrDefault(wish => wish.Id == Wish_2),
                    Count = 100
                },
                new Transaction
                {
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Donate,
                    UserId = UserId_2,
                    User = dbContext.Set<User>().FirstOrDefault(user => user.Id == UserId_2),
                    WishId = Wish_3,
                    Wish = dbContext.Set<Wish>().FirstOrDefault(wish => wish.Id == Wish_3),
                    Count = 50
                },
                new Transaction
                {
                    TransactionType = Frontend.Persistance.Models.Enums.TransactionType.Donate,
                    UserId = UserId_3,
                    User = dbContext.Set<User>().FirstOrDefault(user => user.Id == UserId_3),
                    WishId = Wish_1,
                    Wish = dbContext.Set<Wish>().FirstOrDefault(wish => wish.Id == Wish_1),
                    Count = 100
                });
        }
    }
}
