using System;
using Microsoft.EntityFrameworkCore;

namespace FL.Infrastructure.ReadDatabase.Database
{
    public class LeagueReadModelContext : DbContext
    {
        public DbSet<SeasonViewModel> Season { get; set; }
    }

    public class SeasonViewModel
    {
        public SeasonViewModel()
        {
        }

        public SeasonViewModel(Guid id, string hierarchy)
        {
            this.Id = id;
            this.Hierarchy = hierarchy;
            this.IsRunning = false;
        }

        public Guid Id { get; set; }

        public string Hierarchy { get; set; }

        public string LeagueName { get; set; }

        public bool IsRunning { get; set; }
    }
}