using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Common.Database;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CQRS_Lite_Union_API.Persist.Sql
{
    public class AppContextInitializer : IDatabaseInitializer
    {
        private readonly IServiceProvider _provider;
        private bool _isInitialized;

        public AppContextInitializer(IServiceProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public void Init()
        {
            if (_isInitialized) return;

            using (var scope = _provider.GetService<IServiceScopeFactory>().CreateScope())
            using (var context = scope.ServiceProvider.GetRequiredService<IAppContext>())
            {
                context.DatabaseEnsureCreated();
            }

            _isInitialized = true;
        }
    }
}
