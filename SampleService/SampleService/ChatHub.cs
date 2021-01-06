using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SampleService
{
    public class ChatHub : Hub
    {
        public Task BroadcastMessage(string name, string message)
        {
            return this.Clients.All.SendAsync("broadcastMessage", name, message);
        }

        public Task Echo(string name, string message) =>
            this.Clients.Client(this.Context.ConnectionId)
                .SendAsync("echo", name, $"{message} (echo from server)");
    }
}
