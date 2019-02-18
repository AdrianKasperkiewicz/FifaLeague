using System;
using Microsoft.EntityFrameworkCore;

namespace FL.Infrastructure.ReadDatabase.Database
{
    public class LeagueReadModelContext : DbContext
    {
        public LeagueReadModelContext(DbContextOptions<LeagueReadModelContext> options)
        : base(options)
        {
        }

        public DbSet<SeasonViewModel> Season { get; set; }

        public DbSet<TeamViewModel> Team { get; set; }
    }

}