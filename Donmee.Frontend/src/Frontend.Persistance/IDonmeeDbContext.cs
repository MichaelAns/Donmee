namespace Frontend.Persistance
{
    internal class IDonmeeDbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Wish> Wish { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}
