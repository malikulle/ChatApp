using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.WebUI.Hubs
{
    public class ChatHub : Hub
    {
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }

        public async Task JoinGroup(int chatId)
        {
            await Groups.AddToGroupAsync(GetConnectionId(), chatId.ToString());
        }

        public async Task RemoveFromGroup(int chatId)
        {
            await Groups.RemoveFromGroupAsync(GetConnectionId(), chatId.ToString());
        }
    }
}
