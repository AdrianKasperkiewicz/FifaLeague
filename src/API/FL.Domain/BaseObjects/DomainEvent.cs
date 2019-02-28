using System;

using MediatR;

namespace FL.Domain.BaseObjects
{
    public class DomainEvent : INotification
    {
        private Guid id;

        public Guid Id
        {
            get
            {
                if (this.id == Guid.Empty)
                {
                    this.id = Guid.NewGuid();
                }

                return this.id;
            }
        }

        public int Version { get; set; }
    }
}