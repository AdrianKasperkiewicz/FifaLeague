using System;

using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate
{
    public class Division : Entity
    {
        public Division(Guid guid, string name, int hierarchy)
        {
            base.Id = new Identity(guid);
            this.Name = name;
            this.Hierarchy = hierarchy;
        }

        public string Name { get;  }

        public int Hierarchy { get;  }
    }
}
