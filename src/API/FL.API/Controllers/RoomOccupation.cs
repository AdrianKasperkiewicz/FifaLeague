﻿namespace FL.API.Controllers
{
    using System.Threading.Tasks;
    using FL.API.Infrastructure.SignalRHubs;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;

    [Route("api/[controller]")]
    [ApiController]
    public class RoomOccupation : ControllerBase
    {
        private readonly IHubContext<RoomOccupiedHub> roomOccupationHub;

        public RoomOccupation(IHubContext<RoomOccupiedHub> roomOccupationHub)
        {
            this.roomOccupationHub = roomOccupationHub;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AssignTeam([FromBody] bool isOccupied)
        {
            await this.roomOccupationHub.Clients.All.SendAsync("OccupationChange", isOccupied);

            return this.Ok();
        }
    }
}
