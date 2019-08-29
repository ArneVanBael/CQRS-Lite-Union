using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Lite_Union_API.Common.DependencyResolution
{
    public interface ITypeRegistrar
    {
        void RegisterServices(ITypeRegistrationContainer container);
    }
}
