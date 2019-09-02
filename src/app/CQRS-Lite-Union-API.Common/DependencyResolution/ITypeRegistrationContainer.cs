using System;

namespace CQRS_Lite_Union_API.Common.DependencyResolution
{
    public interface ITypeRegistrationContainer
    {
        void RegisterSingleton<TContract, TImplementation>() where TImplementation : class, TContract;
        void RegisterPerRequest<TContract, TImplementation>() where TImplementation : class, TContract;
        void RegisterTransient<TContract, TImplementation>() where TImplementation : class, TContract;
        void RegisterTransient(Type contract, Type implementation);
        void RegisterDbContext<TContract,TDbContext>() where TDbContext : class;
    }
}