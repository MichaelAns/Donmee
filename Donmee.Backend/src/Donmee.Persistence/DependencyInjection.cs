using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Donmee.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<DonmeeDbContext>(options =>
                options.UseNpgsql(connectionString));
            return services;
        }
    }
}
