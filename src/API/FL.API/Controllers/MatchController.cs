using FL.API.Queries.QueryHandlers.Fixtures;

namespace FL.API.Controllers
{
    using System.Threading.Tasks;
    using FL.API.Queries.QueryHandlers.Matches;
    using FL.Application.CommandHandlers.Matches;
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

        [HttpPost("league")]
        [AllowAnonymous]
        public async Task<ActionResult> PostLeagueMatch([FromBody]AddLeagueMatchResultCommand command)
        {
            return this.Ok(await this.mediator.Send(command));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> PostFriendlyMatch([FromBody]AddMatchResultCommand command)
        {
            return this.Ok(await this.mediator.Send(command));
        }

        [HttpGet("fixture")]
        [AllowAnonymous]
        public async Task<ActionResult> GetFixture()
        {
            return this.Ok(await this.mediator.Send(new GetAllFixtureMatchesQuery()));
        }

        [HttpGet("last/{number}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetLastMatches(int? number)
        {
            return this.Ok(await this.mediator.Send(new GetLastMatchesQuery(number)));
        }
    }
}
