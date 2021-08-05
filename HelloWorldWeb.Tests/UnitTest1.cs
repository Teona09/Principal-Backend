using HelloWorldWeb.Services;
using System;
using System.Linq;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService();

            //Act
            teamService.AddTeamMember("Delia");

            //Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
        }
    }
}
