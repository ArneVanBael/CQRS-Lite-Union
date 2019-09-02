using CQRS_Lite_Union_API.Common.DependencyResolution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CQRS_Lite_Union_API.Infra.DependencyResolution
{
    public class TypeRegistrationContainer :  ITypeRegistrationContainer
    {
        private readonly IServiceCollection _services;

        public TypeRegistrationContainer(IServiceCollection services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public void RegisterSingleton<TContract, TImplementation>() where TImplementation : class, TContract
        {
            _services.AddSingleton(typeof(TContract), typeof(TImplementation));
        }

        public void RegisterPerRequest<TContract, TImplementation>() where TImplementation : class, TContract
        {
            _services.AddScoped(typeof(TContract), typeof(TImplementation));
        }

        public void RegisterTransient<TContract, TImplementation>() where TImplementation : class, TContract
        {
            _services.AddTransient(typeof(TContract), typeof(TImplementation));
        }

        public void RegisterTransient(Type contract, Type implementation)
        {
            _services.AddTransient(contract, implementation);
        }

        public void RegisterDbContext<TContract,TDbContext>() where TDbContext : class
        {
            if (!typeof(DbContext).IsAssignableFrom(typeof(TDbContext))) throw new ArgumentException($"The generic type parameter shoud inherit DbContext. {typeof(TDbContext)} does not inherit from DbContext");

            var methods = typeof(EntityFrameworkServiceCollectionExtensions).GetMethods();
            var method = methods.Single(el => el.Name == "AddDbContext" && el.IsStatic && el.IsGenericMethod &&
                                              el.GetGenericArguments().Length == 2 && el.GetParameters().Length == 4 &&
                                              el.GetParameters()[1].ParameterType == typeof(Action<DbContextOptionsBuilder>));

            var genericMethod = method.MakeGenericMethod(typeof(TContract), typeof(TDbContext));
            genericMethod.Invoke(null, new object[] { _services, null, ServiceLifetime.Scoped, ServiceLifetime.Singleton });
        }
    }
}