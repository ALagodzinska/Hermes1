using Microsoft.AspNetCore.SignalR;

namespace HermesChat.Hubs
{
    public class ChatHub : Hub
    {
        public static List<string> roomList = new List<string>();

        public static List<string> usersList = new List<string>();

        public override async Task OnConnectedAsync()
        {
            var userName = Context.User.Identity.Name;
            if (!usersList.Contains(userName))
            {
                usersList.Add(userName);
            }
            await Clients.All.SendAsync("GetOnlineUsers", usersList);
            await Clients.All.SendAsync("GetRoomList", roomList);
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userName = Context.User.Identity.Name;
            usersList.Remove(userName);
            await Clients.All.SendAsync("GetOnlineUsers", usersList);
            //await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message, string room)
        {
            var user = Context.User.Identity.Name;
            if (message.Length > 0)
            {
                await Clients.Group(room).SendAsync("ReceiveMessage", user, message).ConfigureAwait(true);
            }
        }
        public async Task CreateRoom(string roomName)
        {
            if (!roomList.Contains(roomName))
            {
                roomList.Add(roomName);
            }
            var user = Context.User.Identity.Name;
            await Clients.All.SendAsync("GetRoomList", roomList);
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveMessage", user, " joined to " + roomName).ConfigureAwait(true);
        }
    }
}
