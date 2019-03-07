using System;
using System.Threading;
using System.Threading.Tasks;

using FL.Domain;
using FL.Domain.Aggregates.SeasonAggregate;
using FluentValidation;
using MediatR;

namespace FL.Application.CommandHandlers.Seasons
{
    public class CreateSeasonHandler : IRequestHandler<CreateSeasonCommand, Guid>
    {
        private readonly IRepository<Season> repository;

        public CreateSeasonHandler(IRepository<Season> repository)
        {
            this.repository = repository;
        }

        public async Task<Guid> Handle(CreateSeasonCommand request, CancellationToken cancellationToken)
        {
            var season = new Season(request.StartDate);

            foreach (var division in request.Divisions)
            {
                season.AddDivision(
                    division.Name,
                    division.Hierarchy,
                    division.NumberOfDegraded ?? 0,
                    division.NumberOfPromoted ?? 0);
            }

            await this.repository.Save(season);

            return season.Id.Value;
        }
    }

    public class CreateSeasonCommand : IRequest<Guid>
    {
        public CreateSeasonCommand(DateTime startDate, DivisionViewModel[] divisions)
        {
            this.StartDate = startDate;
            this.Divisions = divisions;
        }

        public DateTime StartDate { get; }

        public DivisionViewModel[] Divisions { get; }
    }

    public class DivisionViewModel
    {
        public DivisionViewModel(
            string name,
            int hierarchy,
            int? numberOfDegraded,
            int? numberOfPromoted)
        {
            this.Name = name;
            this.Hierarchy = hierarchy;
            this.NumberOfDegraded = numberOfDegraded;
            this.NumberOfPromoted = numberOfPromoted;
        }

        public string Name { get; }

        public int Hierarchy { get; }

        public int? NumberOfPromoted { get; }

        public int? NumberOfDegraded { get; }
    }

    public class CreateSeasonCommandValidator : AbstractValidator<CreateSeasonCommand>
    {
        public CreateSeasonCommandValidator()
        {
            this.RuleFor(x => x.StartDate)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(DateTime.Now);

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