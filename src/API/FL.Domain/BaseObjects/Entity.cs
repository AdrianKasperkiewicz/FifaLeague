﻿using System;
using System.Collections.Generic;

namespace FL.Domain.BaseObjects
{
    public abstract class Entity
    {
        private int? requestedHashCode;

        private List<IDomainEvent> domainEvents;

        public virtual Guid Id { get; protected set; }

        public IReadOnlyCollection<IDomainEvent> DomainEvents => this.domainEvents?.AsReadOnly();

        public static bool operator ==(Entity left, Entity right)
        {
            if (object.Equals(left, null))
            {
                return object.Equals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            this.domainEvents = this.domainEvents ?? new List<IDomainEvent>();
            this.domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            this.domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            this.domainEvents?.Clear();
        }

        public bool IsTransient()
        {
            return this.Id == default(Guid);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            var item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
            {
                return false;
            }

            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!this.IsTransient())
            {
                if (!this.requestedHashCode.HasValue)
                {
                    this.requestedHashCode = this.Id.GetHashCode() ^ 31;
                }

                return this.requestedHashCode.Value;
            }

            return base.GetHashCode();
        }
    }
}