using Microsoft.AspNetCore.SignalR;

namespace Workneering.Packages.SignalR.Models
{
    public class ChatHub : Hub
    {
        public async void refresh()
        {
            await Clients.All.SendAsync("refresh");
        }
        public async void count()
        {
            await Clients.All.SendAsync("count");
        }
        public async void refreshChat()
        {
            await Clients.All.SendAsync("refreshChat");
        }
        public async void countChat()
        {
            await Clients.All.SendAsync("countChat");
        }
        public async void refreshRooms()
        {
            await Clients.All.SendAsync("refreshRooms");
        }

    }
}
