using System;
using System.Collections.Generic;

namespace FL.Domain.Aggregates.FixtureAggregate
{
    public class WeekFixture
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<Match> Matches { get; set; }

        public void AddScore()
        {
            throw new NotImplementedException();
        }

        public void Reschedule(Guid matchId)
        {
            throw new NotImplementedException();
        }
    }
}