using System;
using System.Threading;
using System.Threading.Tasks;

using FL.Domain;
using FL.Domain.Aggregates.SeasonAggregate;
using FluentValidation;
using MediatR;

namespace FL.Application.CommandHandlers.Division
{
    public class AddDivisionCommandHandler : AsyncRequestHandler<AddDivisionsCommand>
    {
        private readonly IRepository<Season> repository;
        private readonly IMediator mediator;

        public AddDivisionCommandHandler(IRepository<Season> repository, IMediator mediator)
        {
            this.repository = repository;
            this.mediator = mediator;
        }

        protected override async Task Handle(AddDivisionsCommand request, CancellationToken cancellationToken)
        {
            var season = await this.repository.Get(request.SeasonId);

            foreach (var division in request.Divisions)
            {
                season.AddDivision(new FL.Domain.Aggregates.SeasonAggregate.Division(division.Name, division.Hierarchy));
            }

            await this.repository.Save(season);

            foreach (var @event in season.DomainEvents)
            {
                await this.mediator.Publish(@event);
            }
        }
    }

    public class AddDivisionsCommand : IRequest
    {
        public AddDivisionsCommand(Guid seasonId, DivisionViewModel[] divisions)
        {
            this.SeasonId = seasonId;
            this.Divisions = divisions;
        }

        public Guid SeasonId { get; }

        public DivisionViewModel[] Divisions { get; }
    }

    public class DivisionViewModel
    {
        public DivisionViewModel(string name, int hierarchy)
        {
            this.Name = name;
            this.Hierarchy = hierarchy;
        }

        public string Name { get; }

        public int Hierarchy { get; }
    }

    public class AddDivisionsCommandValidator : AbstractValidator<AddDivisionsCommand>
    {
        public AddDivisionsCommandValidator()
        {
            this.RuleFor(x => x.SeasonId)
                .NotEmpty()
                .NotNull()
                .NotEqual(Guid.NewGuid());

            this.RuleForEach(x => x.Divisions)
                .SetValidator(new DivisionViewModelValidator());
        }
    }

    internal class DivisionViewModelValidator : AbstractValidator<DivisionViewModel>
    {
        public DivisionViewModelValidator()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty();

            this.RuleFor(x => x.Hierarchy)
                .GreaterThan(0);
        }
    }
}