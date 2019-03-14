namespace FL.API.Controllers
{
    using System.Threading.Tasks;
    using FL.API.Queries.QueryHandlers.Teams;
    using FL.Application.CommandHandlers.Teams;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IMediator mediator;

        public TeamController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]CreateTeamCommand command)
        {
            return this.Ok(
               await this.mediator
                    .Send(command));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Get()
        {
            return this.Ok(
               await this.mediator
                    .Send(new GetTeamListQuery()));
        }

        [HttpGet("top")]
        [AllowAnonymous]
        public async Task<ActionResult> TopFive()
        {
            return this.Ok(
                await this.mediator
                    .Send(new GetTopTeamQuery(5)));
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public async Task<ActionResult> FilterByName(string name)
        {
            return this.Ok(
                await this.mediator
                    .Send(new FindTeamByNameQuery(name)));
        }
    }
}