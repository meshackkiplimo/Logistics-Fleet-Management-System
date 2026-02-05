using Microsoft.AspNetCore.SignalR;
using Shared.Models;

namespace FleetService.Hubs;

public class TrackingHub : Hub
{
    public async Task SendLocationUpdate(LocationUpdate location)
    {
        await Clients.All.SendAsync("ReceiveLocationUpdate", location);
    }

    public async Task JoinOrderTracking(string orderId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, orderId);
    }

    public async Task LeaveOrderTracking(string orderId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, orderId);
    }
}
