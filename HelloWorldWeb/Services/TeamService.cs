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
            teamInfo.TeamMembers.Add(new TeamMember("Radu"));
            teamInfo.TeamMembers.Add(new TeamMember("Teona"));
            teamInfo.TeamMembers.Add(new TeamMember("Claudia"));
            teamInfo.TeamMembers.Add(new TeamMember("Leon"));
            teamInfo.TeamMembers.Add(new TeamMember("George"));
            teamInfo.TeamMembers.Add(new TeamMember("Dragos"));
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            foreach (TeamMember member in teamInfo.TeamMembers)
            {
                if (member.Id == id)
                {
                    return member;
                }
            }

            return null;
        }

        public int AddTeamMember(string name)
        {
            TeamMember member = new TeamMember(name);
            this.teamInfo.TeamMembers.Add(member);
            return member.Id;
        }

        public void RemoveMember(int memberIndex)
        {
            this.teamInfo.TeamMembers.Remove(GetTeamMemberById(memberIndex));
        }
    }
}
