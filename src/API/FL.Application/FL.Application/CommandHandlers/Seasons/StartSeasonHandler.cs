using System;
using System.Threading;
using System.Threading.Tasks;

using FL.Domain;
using FL.Domain.Aggregates.SeasonAggregate;
using MediatR;

namespace FL.Application.CommandHandlers.Seasons
{
    public class StartSeasonHandler : AsyncRequestHandler<StartSeasonCommand>
    {
        private readonly IRepository<Season> repository;

        public StartSeasonHandler(IRepository<Season> repository)
        {
            this.repository = repository;
        }

        protected override async Task Handle(StartSeasonCommand request, CancellationToken cancellationToken)
        {
            var season = await this.repository.Get(request.Id);

            season.Start();

            await this.repository.Save(season);
        }
    }

    public class StartSeasonCommand : IRequest
    {
        public StartSeasonCommand(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }
    }
}
