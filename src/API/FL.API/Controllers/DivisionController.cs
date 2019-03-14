namespace FL.API.Controllers
{
    using System;
    using System.Threading.Tasks;
    using FL.API.Queries.QueryHandlers.Divisions;
    using FL.Application.CommandHandlers.Division;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IMediator mediator;

        public DivisionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("AssignTeam")]
        [AllowAnonymous]
        public async Task<ActionResult> AssignTeam([FromBody] AddTeamForDivisionCommand command)
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

        [HttpGet("{id}/teams")]
        [AllowAnonymous]
        public async Task<ActionResult> GetTeams(Guid id)
        {
            return this.Ok(await this.mediator.Send(new GetDivisionTeamsQuery(id)));
        }
    }
}
