using System;
using System.Threading;
using System.Threading.Tasks;

using FL.Domain;
using FL.Domain.Aggregates.SeasonAggregate;
using FluentValidation;
using MediatR;

namespace FL.API.Application.CommandHandlers.Seasons
{
    public class CreateSeasonHandler : IRequestHandler<CreateSeasonCommand, Guid>
    {
        private readonly IRepository<Season> repository;
        private readonly IMediator mediator;

        public CreateSeasonHandler(IRepository<Season> repository, IMediator mediator)
        {
            this.repository = repository;
            this.mediator = mediator;
        }

        public Task<Guid> Handle(CreateSeasonCommand request, CancellationToken cancellationToken)
        {
            var season = new Season(request.Name);
            this.repository.Save(season);

            foreach (var @event in season.DomainEvents)
            {
                this.mediator.Publish(@event);
            }

            return Task.FromResult(season.Id.Value);
        }
    }

    public class CreateSeasonCommand : IRequest<Guid>
    {
        public CreateSeasonCommand(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }

    public class CreateSeasonCommanddValidator : AbstractValidator<CreateSeasonCommand>
    {
        public CreateSeasonCommanddValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}