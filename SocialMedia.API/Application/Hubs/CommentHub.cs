using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Application.Hubs
{
    public class CommentHub : Hub
    {
        public async Task SendComment(string comment)
        {
            await Clients.All.SendAsync("ReceiveComment", comment);
        }

        public Task SendPrivateMessage(string conectionId,string message)
        {
            return Clients.Client(conectionId).SendAsync("PrivateMessage", message);
        }
        public override Task OnConnectedAsync()
        {
            var connection = Context.ConnectionId;
            //Context.User.AddIdentity();
            return base.OnConnectedAsync();
        }
    }
}
