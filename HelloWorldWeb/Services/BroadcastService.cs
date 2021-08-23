﻿namespace HelloWorldWeb.Services
{
    using HelloWorldWeb.Models;
    using Microsoft.AspNetCore.SignalR;

    public class BroadcastService : IBroadcastService
    {
        private readonly IHubContext<MessageHub> messageHub;

        public BroadcastService(IHubContext<MessageHub> messageHub)
        {
            this.messageHub = messageHub;
        }

        public void NewTeamMemberAdded(TeamMember member, int id)
        {
            messageHub.Clients.All.SendAsync("NewTeamMemberAdded", member, member.Id);
        }
    }
}
