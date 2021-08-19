using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
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
            int initialCount = teamService.GetTeamInfo().TeamMembers.Count;
            TeamMember member = new TeamMember();
            member.Name = "Delia";
            teamService.AddTeamMember(member);

            //Assert
            Assert.Equal(initialCount + 1, teamService.GetTeamInfo().TeamMembers.Count);
        }

        //[Fact (Skip = "fails right now later.")] - how to skip a test
        [Fact]
        public void RemoveMemberFromTheTeam()
        {
            // Assume
            ITeamService teamServiceForRemove = new TeamService();

            // Act
            int initialCountForRemove = teamServiceForRemove.GetTeamInfo().TeamMembers.Count;
            TeamMember firstMember = teamServiceForRemove.GetTeamInfo().TeamMembers[0];
            teamServiceForRemove.RemoveMember(firstMember.Id);

            // Assert
            Assert.Equal(initialCountForRemove - 1, teamServiceForRemove.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void UpdateTeamMember()
        {
            TeamService teamService = new TeamService();

            // Act
            teamService.UpdateMemberName(0,"Alex");

            // Assert
            Assert.Equal("Alex", teamService.GetTeamMemberById(0).Name);
        }
    }
}
