using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        private IBroadcastService broadcastService;

        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            //Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            broadcastService = broadcastServiceMock.Object;
            ITeamService teamService = new TeamService(broadcastService);

            //Act
            int initialCount = teamService.GetTeamInfo().TeamMembers.Count;
            teamService.AddTeamMember("Delia");
            TeamMember lastMember = teamService.GetTeamInfo().TeamMembers[initialCount];

            //Assert
            Assert.Equal(initialCount + 1, teamService.GetTeamInfo().TeamMembers.Count);
            List<TeamMember> newList= teamService.GetTeamInfo().TeamMembers;
            broadcastServiceMock.Verify(_ => _.NewTeamMemberAdded(It.IsAny<TeamMember>(), lastMember.Id), Times.Once());
            // other version: 
            //broadcastServiceMock.Verify(_ => _.NewTeamMemberAdded(lastMember, lastMember.Id), Times.Once());
        }

        //[Fact (Skip = "fails right now later.")] - how to skip a test
        [Fact]
        public void RemoveMemberFromTheTeam()
        {
            // Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            broadcastService = broadcastServiceMock.Object;
            ITeamService teamServiceForRemove = new TeamService(broadcastService);
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
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            broadcastService = broadcastServiceMock.Object;
            ITeamService teamService = new TeamService(broadcastService);
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
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            broadcastService = broadcastServiceMock.Object;
            ITeamService teamService = new TeamService(broadcastService);
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
