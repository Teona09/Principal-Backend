namespace HelloWorldWeb.Services
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

        public void TeamMemberDeleted(int id)
        {
            messageHub.Clients.All.SendAsync("TeamMemberDeleted", id);
        }

        public void TeamMemberEdited(int id, string name)
        {
            messageHub.Clients.All.SendAsync("TeamMemberEdited", id, name);
        }
    }
}
