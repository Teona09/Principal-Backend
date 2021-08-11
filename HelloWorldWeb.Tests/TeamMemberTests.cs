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
        [Fact]
        public void GettingAge()
        {
            // Assume
            TeamMember newMember = new TeamMember("Andreea");
            newMember.Birthdate =  new DateTime(2000, 1, 1);
            int expectedAge = DateTime.Now.Year - 2000;

            // Act
            int calculatedAge = newMember.GetAge();

            // Assert
            Assert.Equal(expectedAge, calculatedAge);
        }
    }
}
