using System;

using MediatR;

namespace FL.Domain.BaseObjects
{
    public class DomainEvent : INotification
    {
        private Guid eventId;

        public Guid EventId
        {
            get
            {
                if (this.eventId == Guid.Empty)
                {
                    this.eventId = Guid.NewGuid();
                }

                return this.eventId;
            }
        }

        public int Version { get; set; }
    }
}