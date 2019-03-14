namespace FL.API.Controllers
{
    using System;
    using System.Threading.Tasks;
    using FL.API.Queries.QueryHandlers.Seasons;
    using FL.Application.CommandHandlers.Seasons;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly IMediator mediator;

        public SeasonController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]CreateSeasonCommand command)
        {
            return this.Ok(
               await this.mediator
                    .Send(command));
        }

        [HttpPost("start/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> StartSeason(Guid id)
        {
            return this.Ok(
                await this.mediator.Send(new StartSeasonCommand(id)));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Get()
        {
            return this.Ok(
                 await this.mediator.Send(new GetSeasonListQuery()));
        }
    }
}