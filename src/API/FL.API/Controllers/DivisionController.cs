using System.Threading.Tasks;
using FL.Application.CommandHandlers.Division;
using FL.Application.CommandHandlers.Match;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IMediator mediator;

        public DivisionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]AddDivisionsCommand command)
        {
            return this.Ok(await this.mediator.Send(command));
        }
    }
}
