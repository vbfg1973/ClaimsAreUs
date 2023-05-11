using ClaimsAreUs.Api.Config;
using ClaimsAreUs.Api.Support;
using ClaimsAreUs.Api.Swagger;
using ClaimsAreUs.Common.Extensions;
using ClaimsAreUs.Data;
using ClaimsAreUs.Domain.Support;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAreUs.Api.Extensions
{
    /// <summary>
    ///     Service Collection Extension Methods
    /// </summary>
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
        
        /// <summary>
        ///     Add swagger support and configure appropriately
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void AddSwaggerAndConfig(this IServiceCollection serviceCollection)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            serviceCollection.AddEndpointsApiExplorer();
            serviceCollection.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();
                options.IncludeXmlComments(ApiAssemblyReference.Assembly.XmlCommentsFilePath());
                options.IncludeXmlComments(DomainAssemblyReference.Assembly.XmlCommentsFilePath());
            });
        }

        /// <summary>
        ///     Add API versioning
        /// </summary>
        /// <param name="services"></param>
        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}