using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frontend.Persistance.EntityConfigurations
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(transaction => transaction.Id);
            builder.HasIndex(transaction => transaction.Id)
                .IsUnique();

            builder.Property(transaction => transaction.Date)
                .HasDefaultValueSql("date('now')");

            // When TransactionType is Replenishment
            builder.Property(transaction => transaction.Count)
                .HasDefaultValue(1);

            // Relationships
            builder
                .HasOne(transaction => transaction.User)
                .WithMany(user => user.Transactions);
            builder
                .HasOne(transaction => transaction.Wish)
                .WithMany(wish => wish.Transactions);
        }
    }
}
