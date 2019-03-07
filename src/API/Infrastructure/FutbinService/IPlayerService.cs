using System.Collections.Generic;
using System.Threading.Tasks;

namespace FutbinService
{
    public interface IPlayerService
    {
        Task<List<string>> FindPlayer(string name);
    }
}
