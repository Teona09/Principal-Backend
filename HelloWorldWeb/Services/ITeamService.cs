using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        void AddTeamMember(string name);
        TeamInfo GetTeamInfo();
    }
}