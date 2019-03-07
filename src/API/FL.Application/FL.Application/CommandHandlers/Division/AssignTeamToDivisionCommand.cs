namespace FL.Application.CommandHandlers.Division
{
    using System;
    using FluentValidation;
    using MediatR;

    public class AssignTeamToDivisionCommand : IRequest
    {
        public AssignTeamToDivisionCommand(Guid teamId, Guid seasonId, Guid divisionId)
        {
            this.TeamId = teamId;
            this.SeasonId = seasonId;
            this.DivisionId = divisionId;
        }

        public Guid TeamId { get; }

        public Guid SeasonId { get; }

        public Guid DivisionId { get; }
    }

    public class AddNewTeamToDivisionCommandValidator : AbstractValidator<AssignTeamToDivisionCommand>
    {
        public AddNewTeamToDivisionCommandValidator()
        {
            this.RuleFor(x => x.SeasonId)
                .NotEmpty()
                .NotNull()
                .NotEqual(Guid.NewGuid());

            this.RuleFor(x => x.TeamId)
                  .NotEmpty()
                  .NotNull()
                  .NotEqual(Guid.NewGuid());
        }
    }
}
