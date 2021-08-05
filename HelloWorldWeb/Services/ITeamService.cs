using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        int AddTeamMember(string name);
        TeamInfo GetTeamInfo();
        public void RemoveMember(int memberIndex);

    }
}