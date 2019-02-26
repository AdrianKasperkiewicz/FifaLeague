namespace FL.Domain.Aggregates.SeasonAggregate
{
    using FL.Domain.BaseObjects;

    public class Division : Entity
    {
        public Division(string name, int hierarchy)
        {
            this.Name = name;
            this.Hierarchy = hierarchy;
        }

        public string Name { get;  }

        public int Hierarchy { get;  }
    }
}
