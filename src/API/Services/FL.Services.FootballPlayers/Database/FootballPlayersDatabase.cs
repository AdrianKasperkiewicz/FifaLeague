namespace FL.Services.FootballPlayers.Database
{
    using Microsoft.EntityFrameworkCore;

    public class FootballPlayersDatabase : DbContext
    {
        public FootballPlayersDatabase(DbContextOptions<FootballPlayersDatabase> options)
        : base(options)
        {
        }

        public DbSet<FootballPlayerDTO> FootballPlayers { get; set; }
    }
}
