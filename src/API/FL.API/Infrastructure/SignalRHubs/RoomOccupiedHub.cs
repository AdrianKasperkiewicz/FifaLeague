using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

namespace FL.API.Infrastructure.SignalRHubs
{
    public class RoomOccupiedHub : Hub
    {
        public async Task SendMessage(bool isOccupied)
        {
            await this.Clients.All.SendAsync("OccupationChange", isOccupied);
        }
    }
}
