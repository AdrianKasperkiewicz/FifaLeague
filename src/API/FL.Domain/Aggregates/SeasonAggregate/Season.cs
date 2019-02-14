using System;
using System.Collections.Generic;

using FL.Domain.Aggregates.FixtureAggregate;
using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.SeasonAggregate
{
    public class Season : Entity, IAggregateRoot
    {
        public Season()
        {
            this.Number = 1;
            this.Leagues = new List<League>();
        }

        public int Number { get; }

        public List<League> Leagues;


        public void Start() { }

        public void Finish()
        {
        }

        public void StartNew() { } // returns new season ?
    }

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
            ///??????
        }
    }

    

    public class LeagueTable : Entity
    {
    }
}