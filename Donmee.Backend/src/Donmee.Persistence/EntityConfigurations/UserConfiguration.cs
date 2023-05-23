using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Donmee.Persistence.EntityConfigurations
{
    /// <summary>
    /// Конфигурация для пользователя
    /// </summary>
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Id).IsUnique();

            builder.Property(note => note.Balance).HasDefaultValue(0);
        }
    }
}
