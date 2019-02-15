using System;
using System.Collections.Generic;

namespace FL.Domain.Aggregates.FixtureAggregate
{
    public class Match
    {
        public int HomeTeam { get; private set; }

        public int AwayTeam { get; private set; }

        public bool IsPlayed()
        {
            return this.DateOfPlay.HasValue;
        }

        public List<Goal> Goals { get; private set; }

        public DateTime? DateOfPlay { get; private set; }
    }
}