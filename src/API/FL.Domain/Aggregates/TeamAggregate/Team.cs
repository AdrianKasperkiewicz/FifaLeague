using System;

using FL.Domain.Aggregates.TeamAggregate.Events;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.TeamAggregate
{
    public class Team : Entity, IAggregateRoot
    {
        public Team(string name, string email)
        {
            this.Name = name;
            this.IsActive = true;
            this.EmailAddress = new EmailAddress(email);
            base.Id = new Identity();

            this.AddDomainEvent(new TeamCreatedDomainEvent(this.Id.Value, this.Name, this.EmailAddress.Value));
        }

        public string Name { get; }

        public EmailAddress EmailAddress { get; }

        public bool IsActive { get; }
    }
}