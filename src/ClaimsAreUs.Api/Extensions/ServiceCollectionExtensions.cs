using ClaimsAreUs.Api.Config;
using ClaimsAreUs.Data;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAreUs.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Add database
        /// </summary>
        /// <param name="services"></param>
        /// <param name="appSettings"></param>
        public static void AddDatabase(this IServiceCollection services, AppSettings appSettings)
        {
            services
                .AddDbContext<ClaimsAreUsContext>(options =>
                    options.UseSqlServer(appSettings.Database.ConnectionString)
                );
        }
    }
}