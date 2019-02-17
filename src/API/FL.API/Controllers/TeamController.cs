using System.Threading.Tasks;
using FL.API.Application.CommandHandlers;
using FL.API.Application.CommandHandlers.Teams;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FL.API.Controllers
{
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
        public async Task<ActionResult> Post(CreateTeamCommand command)
        {
            return this.Ok(
               await this.mediator
                    .Send(command));
        }
    }
}