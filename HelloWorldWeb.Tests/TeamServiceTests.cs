using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using System;
using System.Linq;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        private ITimeService timeService;
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
            int initialCount = teamServiceForRemove.GetTeamInfo().TeamMembers.Count;
            TeamMember firstMember = teamServiceForRemove.GetTeamInfo().TeamMembers[0];

            // Act
            teamServiceForRemove.RemoveMember(firstMember.Id);

            // Assert
            Assert.Equal(initialCount - 1, teamServiceForRemove.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void UpdateTeamMember()
        {
            //Assume
            TeamService teamService = new TeamService();
            TeamMember firstMember = teamService.GetTeamInfo().TeamMembers[0];
            int currentId = firstMember.Id;

            // Act
            teamService.UpdateMemberName(currentId,"Alex");

            // Assert
            Assert.Equal("Alex", teamService.GetTeamMemberById(currentId).Name);
        }

        [Fact]
        public void CheckIdProblem()
        {
            //Assume
            ITeamService teamService = new TeamService();
            var memberToBeDeleted = teamService.GetTeamInfo().TeamMembers[teamService.GetTeamInfo().TeamMembers.Count - 2];
            var newMemberName = "Boris";
            //Act
            teamService.RemoveMember(memberToBeDeleted.Id);
            var id = teamService.AddTeamMember(newMemberName);
            teamService.RemoveMember(id);
            //Assert
            var member = teamService.GetTeamInfo().TeamMembers.Find(element => element.Name == newMemberName);
            Assert.Null(member);
        }


    }
}
