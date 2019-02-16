using FL.Domain;
using FL.Domain.Aggregates.SeasonAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FL.API.Application.CommandHandlers.Seasons
{
    public class StartSeasonHandler : AsyncRequestHandler<StartSeasonCommand>
    {
        private readonly ISeasonRepository repository;

        public StartSeasonHandler(ISeasonRepository repository)
        {
            this.repository = repository;
        }
        

        protected override Task Handle(StartSeasonCommand request, CancellationToken cancellationToken)
        {
            var season = this.repository.Get(request.Id);

            season.Start();

            this.repository.Save(season);

            return Task.CompletedTask;
        }
    }

    public class StartSeasonCommand : IRequest
    {
        public StartSeasonCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get;}
    }
}
