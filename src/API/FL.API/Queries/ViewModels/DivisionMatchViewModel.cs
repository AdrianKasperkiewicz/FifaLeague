using System;

namespace FL.API.Queries.ViewModels
{
    public class DivisionMatchViewModel
    {
        public int Id { get; set; }

        public Guid HomeTeamId { get; set; }

        public Guid AwayTeamId { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public int FixtureWeek { get; set; }

        public Guid DivisionId { get; set; }

        public string Division { get; set; }
    }
}
