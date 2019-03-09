using FL.API.Queries.ViewModels;
using FL.Application;
using Microsoft.EntityFrameworkCore;

namespace FL.API.Queries.Database
{
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

        public DbSet<DivisionMatchViewModel> DivisionsMatches { get; set; }
    }
}