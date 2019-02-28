using System.Collections.Generic;

using ReflectionMagic;

namespace FL.Domain.BaseObjects
{
    public abstract class AggregateRoot
    {
        private readonly List<DomainEvent> changes = new List<DomainEvent>();

        public Identity Id { get; protected set; }

        public int Version { get; internal set; }

        public IEnumerable<DomainEvent> GetUncommittedChanges()
        {
            return this.changes;
        }

        public void MarkChangesAsCommitted()
        {
            this.changes.Clear();
        }

        public void LoadsFromHistory(IEnumerable<DomainEvent> history)
        {
            foreach (var e in history)
            {
                this.ApplyChange(e, false);
            }
        }

        protected void ApplyChange(DomainEvent @event)
        {
            this.ApplyChange(@event, true);
        }

        // push atomic aggregate changes to local history for further processing (EventStore.SaveEvents)
        private void ApplyChange(DomainEvent @event, bool isNew)
        {
            this.AsDynamic().Apply(@event);
            if (isNew)
            {
                this.changes.Add(@event);
            }
        }
    }
}
