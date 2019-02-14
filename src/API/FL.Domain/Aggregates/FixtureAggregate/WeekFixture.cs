using System;
using System.Collections.Generic;

using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.FixtureAggregate
{
    public class WeekFixture 
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private List<Match> Matches;
    }

    public class Match
    {
        public int HomeTeam { get; private set; }

        public int AwayTeam { get; private set; }

        public bool IsPlayed()
        {
            return this.DateOfPlay.HasValue;
        }

        private List<Goal> Goals;

        public DateTime? DateOfPlay { get; private set; }
    }

    public class Goal : ValueObject
    {
        public Guid Team { get; set; }

        public int Half { get; set; } // move to enumeration

        public Guid Shooter { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return this.Team;
            yield return this.Half;
            yield return this.Shooter;
        }
    }
}