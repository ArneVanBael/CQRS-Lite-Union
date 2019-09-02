using CQRS_Lite_Union_API.Common.Options;
using CQRS_Lite_Union_API.Persist.Sql.Abstractions;
using Microsoft.Extensions.Options;

namespace CQRS_Lite_Union_API.Persist.Sql
{
    // for EF migrations
    public class AppContextFactory : ContextDesignFactory<AppContext>
    {
        protected override AppContext CreateNewInstance(IOptions<ConnectionStrings> options)
        {
            return new AppContext(options);
        }
    }
}
