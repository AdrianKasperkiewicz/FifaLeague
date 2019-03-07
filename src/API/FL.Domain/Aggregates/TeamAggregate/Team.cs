namespace FL.Domain.Aggregates.TeamAggregate
{
    using System;
    using FL.Domain.Aggregates.TeamAggregate.Events;
    using FL.Domain.BaseObjects;

    public class Team : AggregateRoot
    {
        public Team()
        {
        }

        public Team(string firstName, string lastName, string email)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("First name shoud be given");
            }

            if (!EmailAddress.IsCorrectEmail(email))
            {
                throw new ArgumentException("Email is not Valid");
            }

            base.ApplyChange(new TeamCreatedDomainEvent(Guid.NewGuid(), firstName, lastName, email));
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public EmailAddress EmailAddress { get; private set; }

        public bool IsActive { get; private set; }

        public void Apply(TeamCreatedDomainEvent @event)
        {
            this.FirstName = @event.FirstName;
            this.LastName = @event.LastName;
            this.IsActive = true;
            this.EmailAddress = new EmailAddress(@event.Email);
            base.Id = new Identity();
        }
    }
}