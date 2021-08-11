using HelloWorldWeb.Models;
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
            int initialCount = teamService.GetTeamInfo().TeamMembers.Count;
            teamService.AddTeamMember("Delia");

            //Assert
            Assert.Equal(initialCount + 1, teamService.GetTeamInfo().TeamMembers.Count);
        }

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
            //Assume
            TeamService teamService = new TeamService();

            // Act
            TeamMember firstMember = teamService.GetTeamInfo().TeamMembers[0];
            int currentId = firstMember.Id;
            teamService.UpdateMemberName(currentId,"Alex");

            // Assert
            Assert.Equal("Alex", teamService.GetTeamMemberById(currentId-1).Name);
        }
    }
}
