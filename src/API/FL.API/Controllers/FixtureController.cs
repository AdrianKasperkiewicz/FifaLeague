using System;
using System.Threading.Tasks;

using FL.API.Queries.QueryHandlers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FL.API.Controllers
{
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
    }
}