namespace FL.API.Queries.QueryHandlers.FootballPlayers
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using FL.Services.FootballPlayers;
    using MediatR;

    public class FindFootballPlayerByNameQueryHandler : IRequestHandler<FindFootballPlayerByNameQuery, IList<FootballPlayerDTO>>
    {
        private readonly IPlayerService playerService;

        public FindFootballPlayerByNameQueryHandler(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        public async Task<IList<FootballPlayerDTO>> Handle(FindFootballPlayerByNameQuery request, CancellationToken cancellationToken)
        {
            return await this.playerService.Find(request.Name);
        }
    }

    public class FindFootballPlayerByNameQuery : IRequest<IList<FootballPlayerDTO>>
    {
        public FindFootballPlayerByNameQuery(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
