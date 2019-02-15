using FL.API.Application.CommandHandlers.Seasons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace FL.API.Controllers
{
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
        public async Task<ActionResult> Post([FromBody]CreateSeasonCommand command)
        {
            return this.Ok(
               await this.mediator
                    .Send(command));
        }

        [HttpPost("start")]
        public async Task<ActionResult> StartSeason([FromBody]StartSeasonCommand command)
        {
            return this.Ok(
                await this.mediator.Send(command));
        }
    }
}