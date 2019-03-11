using System;

namespace FL.API.Queries.ViewModels
{
    public class FixtureViewModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public string HomeTeam { get; set; }

        public Guid HomeTeamId { get; set; }

        public string AwayTeam { get; set; }

        public Guid AwayTeamId { get; set; }

        public Guid FixtureId { get; set; }

        public DateTime EndDate { get; set; }

        public Guid SeasonId { get; set; }
    }
}
