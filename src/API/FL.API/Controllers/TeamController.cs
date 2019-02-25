using System.Threading.Tasks;
using FL.API.Queries.QueryHandlers;
using FL.Application.CommandHandlers.Teams;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    }
}