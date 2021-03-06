﻿namespace FL.Application.CommandHandlers.Division
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using FL.Domain;
    using FL.Domain.Aggregates.SeasonAggregate;
    using FluentValidation;
    using MediatR;

    public class AddTeamForDivisionCommandHandler : AsyncRequestHandler<AddTeamForDivisionCommand>
    {
        private readonly IRepository<Season> seasonRepository;

        public AddTeamForDivisionCommandHandler(IRepository<Season> seasonRepository)
        {
            this.seasonRepository = seasonRepository;
        }

        protected override async Task Handle(AddTeamForDivisionCommand request, CancellationToken cancellationToken)
        {
            var season = await this.seasonRepository.Get(request.SeasonId);

            season.AddTeam(request.DivisionId, request.TeamId);

            await this.seasonRepository.Save(season);
        }
    }

    public class AddTeamForDivisionCommand : IRequest
    {
        public AddTeamForDivisionCommand(Guid seasonId, Guid divisionId, Guid teamId)
        {
            this.SeasonId = seasonId;
            this.DivisionId = divisionId;
            this.TeamId = teamId;
        }

        public Guid SeasonId { get; }

        public Guid DivisionId { get; }

        public Guid TeamId { get; }
    }

    public class CreateTeamsForDivisionCommandValidator : AbstractValidator<AddTeamForDivisionCommand>
    {
        public CreateTeamsForDivisionCommandValidator()
        {
            this.RuleFor(x => x.SeasonId)
                .NotEmpty();

            this.RuleFor(x => x.TeamId)
                .NotEmpty();

            this.RuleFor(x => x.DivisionId)
                .NotEmpty();
        }
    }
}
