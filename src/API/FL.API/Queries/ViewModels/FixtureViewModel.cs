using System;

namespace FL.API.Queries.ViewModels
{
    public class FixtureViewModel
    {
        public int Id { get; set; }

        public Guid FixtureId { get; set; }

        public Guid SeasonId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid DivisionId { get; set; }

        public int WeekNumber { get; set; }
    }
}
