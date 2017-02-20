using System;

namespace Repositories
{
    public abstract class EntityBase
    {
         public Guid Id { get; set; }

        public bool Deleted { get; set; }
    }
}