using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Common.Database;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS_Lite_Union_API.Persist.Sql.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterPersistSQLDependencies(this IServiceCollection services)
        {
            // register depencies for persist sql project
            services.AddSingleton<IDatabaseInitializer, AppContextInitializer>();
            services.AddDbContext<IAppContext, AppContext>();
        }
    }
}
