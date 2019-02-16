using System;
using System.Collections.Generic;

using FL.Domain.Aggregates.FixtureAggregate;

namespace FL.Domain.Factories
{
    public class FixtureFactory
    {
        private readonly List<Guid> teams;

        private readonly DateTime startDate;

        public FixtureFactory(List<Guid> teams, DateTime startDate)
        {
            this.teams = teams;
            this.startDate = startDate;
        }

        public List<WeekFixture> Build()
        {
            return new List<WeekFixture>();
        }
    }
}
