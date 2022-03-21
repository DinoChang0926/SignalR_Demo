using Microsoft.AspNetCore.SignalR;

namespace SignalR_Demo.SignalR
{
    public class ChatHub : Hub
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatHub(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }



        public async Task SendMessage(string user, string message, string group = "ReceiveMessage")
        {
            await _hubContext.Clients.All.SendAsync(group, user, message);
        }
    }
}
