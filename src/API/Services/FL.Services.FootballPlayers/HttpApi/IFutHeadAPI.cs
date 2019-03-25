namespace FL.Services.FootballPlayers.HttpApi
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Refit;

    internal interface IFutHeadAPI
    {
        [Get("/quicksearch/player/19/?term={name}")]
        Task<List<FutHeadFootballPlayer>> SearchPlayer(string name);
    }
}
