﻿using System.Threading.Tasks;

using FL.API.Queries.QueryHandlers;
using FL.Application.CommandHandlers.Division;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IMediator mediator;

        public DivisionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateTeamsForDivisions([FromBody]CreateTeamsForDivisionCommand command)
        {
            return this.Ok(await this.mediator.Send(command));
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public async Task<ActionResult> SearchForDivision(string name)
        {
            return this.Ok(await this.mediator.Send(new GetDivisionByNameQuery(name)));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetDivisions()
        {
            return this.Ok(await this.mediator.Send(new GetDivisionsQuery()));
        }
    }
}
