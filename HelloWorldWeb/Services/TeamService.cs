using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;

        public TeamService()
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team 3",
                TeamMembers = new List<TeamMember>(),

            };
            teamInfo.TeamMembers.Add(new TeamMember(1, "Radu"));
            teamInfo.TeamMembers.Add(new TeamMember(2, "Teona"));
            teamInfo.TeamMembers.Add(new TeamMember(3, "Claudia"));
            teamInfo.TeamMembers.Add(new TeamMember(4, "Leon"));
            teamInfo.TeamMembers.Add(new TeamMember(5, "George"));
            teamInfo.TeamMembers.Add(new TeamMember(6, "Dragos"));
            
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public int AddTeamMember(string name)
        {
            int newId = teamInfo.TeamMembers.Count()+1;
            this.teamInfo.TeamMembers.Add(new TeamMember(newId,name));
            return newId;
        }

        public void RemoveMember(int memberIndex)
        {
            this.teamInfo.TeamMembers.RemoveAt(memberIndex);
        }
    }
}
