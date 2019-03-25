namespace FL.API.Queries.QueryHandlers.FootballPlayers
{
    using System.Threading;
    using System.Threading.Tasks;

    using FL.Services.FootballPlayers;
    using MediatR;

    public class GetFootballPlayerQueryHandler : IRequestHandler<GetFootballPlayerQuery, FootballPlayerDTO>
    {
        private readonly IPlayerService playerService;

        public GetFootballPlayerQueryHandler(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        public async Task<FootballPlayerDTO> Handle(GetFootballPlayerQuery request, CancellationToken cancellationToken)
        {
            return await this.playerService.Get(request.Id);
        }
    }

    public class GetFootballPlayerQuery : IRequest<FootballPlayerDTO>
    {
        public GetFootballPlayerQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; }
    }
}
