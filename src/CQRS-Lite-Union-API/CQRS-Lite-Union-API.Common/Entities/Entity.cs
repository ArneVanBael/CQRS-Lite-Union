using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS_Lite_Union_API.Common.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Created = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public DateTime Created { get; private set; }
    }
}
