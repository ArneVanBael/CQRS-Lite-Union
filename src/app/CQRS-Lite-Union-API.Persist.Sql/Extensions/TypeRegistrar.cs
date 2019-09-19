using CQRS_Lite_Union_API.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS_Lite_Union_API.Persist.Sql.Extensions
{
    public static class TypeRegistrar
    {
        public static void RegisterPersistSQLDependencies(this IServiceCollection services)
        {
            // register depencies for persist sql project
            services.AddDbContext<IAppContext, AppContext>();
        }
    }
}
