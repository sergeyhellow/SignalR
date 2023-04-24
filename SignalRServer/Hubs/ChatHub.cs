using Microsoft.AspNetCore.SignalR;
using SignalRModels.Models;

namespace SignalRServer.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
           await  Clients.All.SendAsync("ReceiveMessage", message);

        }
    }
}
