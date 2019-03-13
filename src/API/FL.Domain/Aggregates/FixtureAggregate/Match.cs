using System;

using FL.Domain.BaseObjects;

namespace FL.Domain.Aggregates.FixtureAggregate
{
    public class Match : Entity
    {
        public Match(Guid id, Guid homeTeam, Guid awayTeam, bool isRescheduled = false, bool isPostopne = false)
        {
            base.Id = new Identity(id);
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.IsRescheduled = isRescheduled;
            this.IsPostponed = isPostopne;
        }

        public Guid HomeTeam { get; private set; }

        public Guid AwayTeam { get; private set; }

        public bool IsRescheduled { get; private set; }

        public bool IsPostponed { get; private set; }

        public void Postpone()
        {
            this.IsPostponed = true;
        }
    }
}