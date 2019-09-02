using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Common.DependencyResolution;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Lite_Union_API.Persist.Sql.DependencyResolution
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public void RegisterServices(ITypeRegistrationContainer container)
        {
            container.RegisterDbContext<IAppContext, AppContext>();
        }
    }
}
