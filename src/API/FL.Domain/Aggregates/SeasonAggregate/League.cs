using System;
using System.Collections.Generic;

using FL.Domain.Aggregates.FixtureAggregate;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate
{
    public class League : Entity
    {
        public League(string name, int hierarchyNumber, IList<Guid> teams)
        {
            this.Name = name;
            this.HierarchyNumber = hierarchyNumber;
        }

        private string Name { get; }

        private int HierarchyNumber { get; }

        public LeagueTable LeagueTable { get; }

        public WeekFixture Fixutre { get; }

        public void GenerateFixture()
        {
        }
    }
}