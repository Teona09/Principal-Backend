using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamMemberTests
    {
        private Mock<ITimeService> timeMock;

        private void InitializeTimeSeriviceMock()
        {
            timeMock = new Mock<ITimeService>();
            timeMock.Setup(_ => _.Now()).Returns(new DateTime(2021, 8, 12));
            
        }

        [Fact]
        public void NoEqulsMembers()
        {
            // Assume
            InitializeTimeSeriviceMock();
            var timeService = timeMock.Object;

            // Act
            TeamMember member1 = new TeamMember("Tudor", timeService);
            TeamMember member2 = new TeamMember("Tudor", timeService);

            // Assert
            Assert.False(member1.Equals(member2));

        }
        [Fact]
        public void TestIdIncremetation()
        {
            //Assume
            InitializeTimeSeriviceMock();
            var timeService = timeMock.Object;

            //Act
            TeamMember teamMember = new TeamMember("Elena", timeService);
            int nextId = TeamMember.GetIdCount();

            //Assert
            Assert.Equal(teamMember.Id + 1, nextId);
        }
            [Fact]
        public void GettingAge()
        {
            // Assume
            InitializeTimeSeriviceMock();
            var timeService = timeMock.Object;
            TeamMember newMember = new TeamMember("Andreea",timeService);
            newMember.Birthdate =  new DateTime(2000, 1, 1);

            // Act
            int calculatedAge = newMember.GetAge();

            // Assert
            timeMock.Verify(library => library.Now(), Times.AtMostOnce());
            Assert.Equal(21, calculatedAge);
            
        }

    }
}
