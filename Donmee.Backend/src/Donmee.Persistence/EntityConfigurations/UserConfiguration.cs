using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donmee.Persistence.EntityConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Id).IsUnique();

            builder.Property(note => note.Balance).HasDefaultValue(0);
            //builder.Property(note => note.Bonus).HasDefaultValue(0);
        }
    }
}
