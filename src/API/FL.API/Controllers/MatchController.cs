using System;
using System.IO;
using System.Threading.Tasks;

using FL.API.Application.CommandHandlers.Match;
using FL.Infrastructure.OCR;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

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

        [HttpPost("facts")]
        [AllowAnonymous]
        public async Task<ActionResult> PostFacts(IFormFile file)
        {
            Byte[] imagebytes;

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                imagebytes = ms.ToArray();
            }
            var reader = new OCRReader();
            var result  = reader.Read(imagebytes);

            return this.Ok(result);
        }
    }
}