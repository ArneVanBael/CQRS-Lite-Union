
using CQRS_Lite_Union_API.Common.DependencyResolution;
using CQRS_Lite_Union_API.Infra.DependencyResolution;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
namespace CQRS_Lite_Union_API.Infra.Extensions
{
    public static class DependencyLoaderExtensions
    {
        public static void RegisterTypes(this IServiceCollection services, IEnumerable<string> dlls)
        {
            var container = new TypeRegistrationContainer(services);
            foreach (var dll in dlls)
            {
                var assembly = Assembly.LoadFrom(dll);
                var types = assembly.GetTypes();

                foreach (var type in types.Where(el => typeof(ITypeRegistrar).IsAssignableFrom(el) && el.IsClass && !el.IsAbstract))
                {
                    var instance = (ITypeRegistrar)Activator.CreateInstance(type);
                    instance.RegisterServices(container);
                }
            }
        }
    }
}
