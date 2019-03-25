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
                .Select(x => new FootballPlayerDTO
                {
                    Id = x.id,
                    FirstName = x.first_name,
                    LastName = x.last_name,
                    FullName = x.full_name,
                    ImageUrl = x.image
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
                .Except(this.database.FootballPlayers)
                .ToList()
                .ForEach(x => this.database.FootballPlayers.Add(x));

            this.database.SaveChangesAsync();
        }
    }
}
