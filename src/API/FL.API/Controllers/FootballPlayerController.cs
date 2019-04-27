namespace FL.API.Controllers
{
    using System;
    using System.Threading.Tasks;
    using FL.API.Queries.QueryHandlers.Divisions;
    using FL.API.Queries.QueryHandlers.FootballPlayers;
    using FL.Application.CommandHandlers.Division;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayerController : ControllerBase
    {
        private readonly IMediator mediator;

        public FootballPlayerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("search/{name}")]
        [AllowAnonymous]
        public async Task<ActionResult> SearchByName(string name)
        {
            return this.Ok(await this.mediator.Send(new FindFootballPlayerByNameQuery(name)));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> SearchForDivision(int id)
        {
            return this.Ok(await this.mediator.Send(new GetFootballPlayerQuery(id)));
        }
    }
}
