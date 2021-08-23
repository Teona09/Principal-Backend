using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.SignalR;
using Moq;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        private Mock<IHubContext<MessageHub>> messageHubMock;
        private Mock<IHubClients> hubClientsMock;
        private Mock<IClientProxy> hubAllClientsMock;

        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            //Assume
            InitializeMessageHubMock();
            ITeamService teamService = new TeamService(GetMockedMessageHub());

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
            InitializeMessageHubMock();
            ITeamService teamServiceForRemove = new TeamService(GetMockedMessageHub());
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
            InitializeMessageHubMock();
            ITeamService teamService = new TeamService(GetMockedMessageHub());
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
            InitializeMessageHubMock();
            ITeamService teamService = new TeamService(GetMockedMessageHub());
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


        private void InitializeMessageHubMock()
        {
            // https://www.codeproject.com/Articles/1266538/Testing-SignalR-Hubs-in-ASP-NET-Core-2-1
            hubAllClientsMock = new Mock<IClientProxy>();
            hubClientsMock = new Mock<IHubClients>();
            hubClientsMock.Setup(_ => _.All).Returns(hubAllClientsMock.Object);
            messageHubMock = new Mock<IHubContext<MessageHub>>();
            messageHubMock.SetupGet(_ => _.Clients).Returns(hubClientsMock.Object);
        }

        private IHubContext<MessageHub> GetMockedMessageHub()
        {
            if (messageHubMock == null)
            {
                InitializeMessageHubMock();
            }
            return messageHubMock.Object;
        }
    }
}
