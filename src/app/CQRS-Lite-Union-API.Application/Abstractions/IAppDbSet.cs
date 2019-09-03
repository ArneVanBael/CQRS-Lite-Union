using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CQRS_Lite_Union_API.Application.Abstractions
{
    public interface IAppDbSet<T>
    {
        IAppDbSet<T> Include<U>(Expression<Func<T, U>> navigationPropertyPath);
    }
}
