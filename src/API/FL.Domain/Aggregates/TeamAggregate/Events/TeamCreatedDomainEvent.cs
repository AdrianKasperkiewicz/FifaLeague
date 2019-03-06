using System;

using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.TeamAggregate.Events
{
    public class TeamCreatedDomainEvent : DomainEvent
    {
        public TeamCreatedDomainEvent(Guid teamId, string firstName, string lastName, string email)
        {
            this.TeamId = teamId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        public Guid TeamId { get; }

        public string FirstName { get;  }

        public string LastName { get; }

        public string Email { get;  }
    }
}