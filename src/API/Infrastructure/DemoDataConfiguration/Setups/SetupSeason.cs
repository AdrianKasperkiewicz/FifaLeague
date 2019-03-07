﻿using System;
using FL.Application.CommandHandlers.Seasons;
using MediatR;

namespace DemoDataConfiguration.Setups
{
    public class SetupSeason
    {
        private readonly IMediator mediator;

        public SetupSeason(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Seed()
        {
            this.mediator.Send(new CreateSeasonCommand(DateTime.Now.AddDays(3), GetNewDivision()));
        }

        private static DivisionViewModel[] GetNewDivision()
        {
            return new DivisionViewModel[]
            {
                new DivisionViewModel("Ekstraklasa", 1, 2, 0),
                new DivisionViewModel("Pierwsza Liga", 2, 2, 2),
                new DivisionViewModel("Druga Liga", 3, 0, 2),
            };
        }
    }
}
