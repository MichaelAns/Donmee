using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donmee.Persistence.EntityConfigurations
{
    /// <summary>
    /// Конфигурация для желаний
    /// </summary>
    internal class WishConfiguration : IEntityTypeConfiguration<Wish>
    {
        public void Configure(EntityTypeBuilder<Wish> builder)
        {
            builder.HasKey(wish => wish.Id);
            builder.HasIndex(wish => wish.Id)
                .IsUnique();
        }
    }
}
