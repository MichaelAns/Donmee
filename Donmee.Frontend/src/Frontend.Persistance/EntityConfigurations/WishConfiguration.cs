using Frontend.Persistance.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frontend.Persistance.EntityConfigurations
{
    internal class WishConfiguration : IEntityTypeConfiguration<Wish>
    {
        public void Configure(EntityTypeBuilder<Wish> builder)
        {
            builder.HasKey(wish => wish.Id);
            builder.HasIndex(wish => wish.Id)
                .IsUnique();

            builder.Property(wish => wish.Name)
                .HasMaxLength(50);
            builder.Property(wish => wish.Description)
                .HasMaxLength(500);
            builder.Property(wish => wish.WishStatus)
                .HasMaxLength((int) WishStatus.Active);
        }
    }
}
