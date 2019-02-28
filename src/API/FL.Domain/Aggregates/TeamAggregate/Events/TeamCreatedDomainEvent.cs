using System;

using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.TeamAggregate.Events
{
    public class TeamCreatedDomainEvent : DomainEvent
    {
        public TeamCreatedDomainEvent(Guid teamId, string name, string email)
        {
            this.TeamId = teamId;
            this.Name = name;
            this.Email = email;
        }

        public Guid TeamId { get; }

        public string Name { get;  }

        public string Email { get;  }
    }
}