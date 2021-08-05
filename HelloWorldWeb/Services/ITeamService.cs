using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        int AddTeamMember(string name);

        TeamInfo GetTeamInfo();

        TeamMember GetTeamMemberById(int id);

        public void RemoveMember(int memberIndex);
    }
}