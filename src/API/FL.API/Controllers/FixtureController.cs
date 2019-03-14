namespace FL.API.Controllers
{
    using System;
    using System.Threading.Tasks;
    using FL.API.Queries.QueryHandlers.Fixtures;
    using FL.API.Queries.QueryHandlers.Matches;
    using FL.Application.CommandHandlers.Fixtures;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class FixtureController : ControllerBase
    {
        private readonly IMediator mediator;

        public FixtureController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("current")]
        [AllowAnonymous]
        public async Task<ActionResult> Get()
        {
            return this.Ok(await this.mediator.Send(new GetCurrentSeasonFixturesQuery()));
        }

        [HttpGet("{divisionId}")]
        [AllowAnonymous]
        public async Task<ActionResult> Get(Guid divisionId)
        {
            return this.Ok(await this.mediator.Send(new GetFixtureByDivisionQuery(divisionId)));
        }

        [HttpGet("Next")]
        [AllowAnonymous]
        public async Task<ActionResult> NextMatches()
        {
            return this.Ok(await this.mediator.Send(new GetCurrentFixtureQuery()));
        }

        [HttpGet("possiblereschedulefixtures/{matchId}")]
        [AllowAnonymous]
        public async Task<ActionResult> FindPossibleRescheduleFixtures(Guid matchId)
        {
            return this.Ok(await this.mediator.Send(new FindPossibleRescheduleFixturesQuery(matchId)));
        }

        [HttpPost("reschedule")]
        [AllowAnonymous]
        public async Task<ActionResult> RescheduleMatch([FromBody]RescheduleMatchCommand command)
        {
            return this.Ok(await this.mediator.Send(command));
        }
    }
}