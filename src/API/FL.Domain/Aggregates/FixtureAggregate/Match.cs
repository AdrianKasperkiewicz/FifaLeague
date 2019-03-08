using System;
using System.Collections.Generic;

namespace FL.Domain.Aggregates.FixtureAggregate
{
    public class Match
    {
        public Match(Guid homeTeam, Guid awayTeam)
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
        }

        public Guid HomeTeam { get; private set; }

        public Guid AwayTeam { get; private set; }
    }
}