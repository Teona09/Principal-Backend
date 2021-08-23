using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface IBroadcastService
    {
        void NewTeamMemberAdded(TeamMember member, int id);
    }
}