using AutoMapper;
using CQRS_Lite_Union_API.Common.Options;
using CQRS_Lite_Union_API.Infra.Extensions;
using CQRS_Lite_Union_API.Persist.Sql.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS_Lite_Union_API.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDepenencyResolution(this IServiceCollection services)
        {
            services.RegisterInfraDependencies();
            services.RegisterPersistSQLDependencies();
        }

        public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
        }

        public static void AddAutomapperAssemblies(this IServiceCollection services)
        {
            var assemblies = new[]
            {
                typeof(Startup).Assembly
            };

            services.AddAutoMapper(assemblies);
        }
    }
}
