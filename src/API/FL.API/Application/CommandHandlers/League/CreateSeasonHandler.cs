using FL.Domain;
using FL.Domain.Aggregates.SeasonAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FL.API.Application.CommandHandlers.League
{
    public class CreateSeasonHandler : IRequestHandler<CreateLeagueCommand, Guid>
    {
        private readonly IRepository<Season> repository;

        public CreateSeasonHandler(IRepository<Season> repository)
        {
            this.repository = repository;
        }

        public Task<Guid> Handle(CreateLeagueCommand request, CancellationToken cancellationToken)
        {
            var season = new Season(request.Name);

            this.repository.Save(season);

            return Task.FromResult(season.Id);
        }
    }

    public class CreateLeagueCommand : IRequest<Guid>
    {
        public CreateLeagueCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
