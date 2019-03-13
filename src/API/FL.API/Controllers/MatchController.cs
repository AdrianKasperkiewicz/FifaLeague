namespace FL.API.Controllers
{
    using System.Threading.Tasks;
    using FL.API.Queries.QueryHandlers;
    using FL.Application.CommandHandlers.Match;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMediator mediator;

        public MatchController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]AddMatchCommand command)
        {
            return this.Ok(await this.mediator.Send(command));
        }

        [HttpGet("fixture")]
        [AllowAnonymous]
        public async Task<ActionResult> GetFixture()
        {
            return this.Ok(await this.mediator.Send(new GetAllFixtureMatchesQuery()));
        }
    }
}
