using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Lite_Union_API.Common.Database
{
    public interface IDatabaseInitializer
    {
        void Init();
    }
}
