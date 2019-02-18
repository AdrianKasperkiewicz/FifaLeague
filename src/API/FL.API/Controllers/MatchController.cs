using FL.API.Application.CommandHandlers.Match;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FL.API.Controllers
{

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
            return Ok(await this.mediator.Send(command));
        }
    }
}
