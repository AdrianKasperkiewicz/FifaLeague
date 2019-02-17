using System;
using Microsoft.EntityFrameworkCore;

namespace FL.Infrastructure.ReadDatabase.Database
{
    public class LeagueReadModelContext : DbContext
    {
        public DbSet<SeasonViewModel> Season { get; set; }
    }

}