using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
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
        private ITimeService timeService;

        public TeamMemberTests()
        {
            timeService = new FakeTimeService();
        }

        [Fact]
        public void NoEqulsMembers()
        {
            // Assume

            // Act
            TeamMember member1 = new TeamMember("Tudor", timeService);
            TeamMember member2 = new TeamMember("Tudor", timeService);

            // Assert
            Assert.False(member1.Equals(member2));

        }
        [Fact]
        public void TestIdIncremetation()
        {
            TeamMember teamMember = new TeamMember("Elena", timeService);
            int nextId = TeamMember.GetIdCount();
            Assert.Equal(teamMember.Id + 1, nextId);
        }
            [Fact]
        public void GettingAge()
        {
            // Assume
            TeamMember newMember = new TeamMember("Andreea",timeService);
            newMember.Birthdate =  new DateTime(2000, 1, 1);
            int expectedAge = DateTime.Now.Year - 2000;

            // Act
            int calculatedAge = newMember.GetAge();

            // Assert
            Assert.Equal(expectedAge, calculatedAge);
        }

        internal class FakeTimeService : ITimeService
        {
            public DateTime Now()
            {
                return new DateTime(2021, 08, 11);
            }
        }
    }
}
