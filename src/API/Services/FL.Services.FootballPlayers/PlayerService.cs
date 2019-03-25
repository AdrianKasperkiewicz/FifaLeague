namespace FL.Services.FootballPlayers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using FL.Services.FootballPlayers.Database;
    using FL.Services.FootballPlayers.HttpApi;
    using Microsoft.EntityFrameworkCore;

    internal class PlayerService : IPlayerService
    {
        private readonly FootballPlayersDatabase database;
        private readonly IFutHeadAPI futHeadAPI;

        public PlayerService(FootballPlayersDatabase db, IFutHeadAPI futHeadAPI)
        {
            this.database = db;
            this.futHeadAPI = futHeadAPI;
        }

        public async Task<IList<FootballPlayerDTO>> Find(string name)
        {
            var result = (await this.futHeadAPI.SearchPlayer(name))
                .Where(x => x.revision_type == "NIF")
                .GroupBy(x => x.player_id, (key, group) => group.First())
                .Select(x => new FootballPlayerDTO
                {
                    Id = x.id,
                    FirstName = x.first_name,
                    LastName = x.last_name,
                    FullName = x.full_name,
                    ImageUrl = x.image,
                    Club = x.club_name
                })
                .ToList();

            this.AddToDabase(result);

            return result;
        }

        public async Task<FootballPlayerDTO> Get(int id)
        {
            return await this.database
                .FootballPlayers
                .FirstAsync(x => x.Id == id);
        }

        private void AddToDabase(IList<FootballPlayerDTO> footballPlayers)
        {
            footballPlayers
                .Where(x => !this.database.FootballPlayers.Any(y => y.Id == x.Id))
                .ToList()
                .ForEach(x => this.database.FootballPlayers.Add(x));

            this.database.SaveChangesAsync();
        }
    }
}
