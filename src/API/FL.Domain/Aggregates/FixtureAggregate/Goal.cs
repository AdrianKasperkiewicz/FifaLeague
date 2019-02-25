using System;
using System.Collections.Generic;
using FL.Domain.Aggregates.FixtureAggregate.HalfEnumeration;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.FixtureAggregate
{
    public class Goal : ValueObject
    {
        public Guid Team { get; set; }

        public MatchHalf Half { get; set; }

        public Guid Shooter { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.Team;
            yield return this.Half;
            yield return this.Shooter;
        }
    }
}