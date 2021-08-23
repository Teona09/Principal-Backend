namespace HelloWorldWeb.Services
{
    using HelloWorldWeb.Models;

    public interface IBroadcastService
    {
        void NewTeamMemberAdded(TeamMember member, int id);

        void TeamMemberDeleted(int id);

        void TeamMemberEdited(int memberId, string name);
    }
}