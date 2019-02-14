using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.TeamAggregate.Events
{
    public class TeamCreatedDomainEvent : IDomainEvent
    {
        public TeamCreatedDomainEvent(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name { get;  }

        public string Email { get;  }
    }
}