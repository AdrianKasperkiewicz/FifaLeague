using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FutbinService
{
    internal class PlayerSearch : IPlayerService
    {
        private readonly FutbinHttpClient httpclient;

        public PlayerSearch(FutbinHttpClient httpclient)
        {
            this.httpclient = httpclient;
        }

        public async Task<List<string>> FindPlayer(string name)
        {
            var link = $"search?year=19&extra=1&term=ronald";
            var response = await this.httpclient.Client.GetStringAsync(link);

            var players = JsonConvert.DeserializeObject<Player[]>(response);

            return players.Select(x => x.Full_name).ToList();
        }
    }

    internal class Player
    {
        public string Full_name { get; set; }

        public int Rare_type { get; set; }

        public int Id { get; set; }
    }
}