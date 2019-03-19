using System;

namespace FL.API.Queries.ViewModels
{
    public class MatchViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }
    }
}
