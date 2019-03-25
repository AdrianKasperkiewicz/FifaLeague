using System.Collections.Generic;
using System.Threading.Tasks;

namespace FL.Services.FootballPlayers
{
    public interface IPlayerService
    {
        Task<IList<FootballPlayerDTO>> Find(string name);

        Task<FootballPlayerDTO> Get(int id);
    }
}