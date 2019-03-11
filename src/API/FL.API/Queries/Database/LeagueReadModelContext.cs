namespace FL.API.Queries.Database
{
    using FL.API.Queries.QueryHandlers;
    using FL.API.Queries.ViewModels;
    using Microsoft.EntityFrameworkCore;

    public class LeagueReadModelContext : DbContext
    {
        public LeagueReadModelContext(DbContextOptions<LeagueReadModelContext> options)
        : base(options)
        {
        }

        public DbSet<SeasonViewModel> Seasons { get; set; }

        public DbSet<DivisionViewModel> Divisions { get; set; }

        public DbSet<TeamViewModel> Teams { get; set; }

        public DbSet<DivisionTeamViewModel> DivisionTeams { get; set; }

        public DbSet<FixtureViewModel> Fixtures { get; set; }
    }
}