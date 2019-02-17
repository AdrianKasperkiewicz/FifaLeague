using MediatR;

using System;
using System.Threading;
using System.Threading.Tasks;
using FL.Domain;
using FL.Domain.Aggregates.SeasonAggregate;

namespace FL.API.Application.CommandHandlers.Seasons
{
    public class CreateSeasonHandler : IRequestHandler<CreateSeasonCommand, Guid>
    {
        private readonly IRepository<Season> repository;

        public CreateSeasonHandler(IRepository<Season> repository)
        {
            this.repository = repository;
        }

        public Task<Guid> Handle(CreateSeasonCommand request, CancellationToken cancellationToken)
        {
            var season = new Season(request.Name);
            this.repository.Save(season);

            return Task.FromResult(season.Id);
        }
    }

    public class CreateSeasonCommand : IRequest<Guid>
    {
        public string Name { get; }
    }
}