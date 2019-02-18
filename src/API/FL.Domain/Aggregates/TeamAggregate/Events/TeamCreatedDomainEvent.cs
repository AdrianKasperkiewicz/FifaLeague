using System;

using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.TeamAggregate.Events
{
    public class TeamCreatedDomainEvent : IDomainEvent
    {
        public TeamCreatedDomainEvent(Guid id, string name, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
        }

        public Guid Id { get; }

        public string Name { get;  }

        public string Email { get;  }
    }
}