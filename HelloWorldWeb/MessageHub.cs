using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace HelloWorldWeb
{
    internal class MessageHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}