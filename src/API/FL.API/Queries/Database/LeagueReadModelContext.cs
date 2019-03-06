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

        public DbSet<SeasonViewModel> Season { get; set; }

        public DbSet<DivisionViewModel> Division { get; set; }

        public DbSet<TeamViewModel> Team { get; set; }

        public DbSet<DivisionTeamViewModel> DivisionTeam { get; set; }
    }
}