using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donmee.Persistence.EntityConfigurations
{
    /// <summary>
    /// Конфигурация для транзакций
    /// </summary>
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder
                .HasKey(transaction => transaction.Id);
            builder
                .HasIndex(transaction => transaction.Id)
                .IsUnique();

            builder
                .Property(transaction => transaction.Date)
                .HasDefaultValueSql("NOW()");

            // When TransactionType is Replenishment
            builder
                .Property(transaction => transaction.Count)
                .HasDefaultValue(1);

            // Relationships
            builder
                .HasOne(transaction => transaction.User)
                .WithMany(user => user.Transactions)
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            builder
                .HasOne(transaction => transaction.Wish)
                .WithMany(wish => wish.Transactions)
                .HasForeignKey("WishId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
