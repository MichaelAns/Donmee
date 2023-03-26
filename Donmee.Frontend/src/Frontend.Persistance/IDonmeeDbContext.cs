namespace Frontend.Persistance
{
    public interface IDonmeeDbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Wish> Wish { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}
