using System.Collections.Generic;

namespace HelloWorldWeb.Models
{
    public class TeamInfo
    {
        public string Name { get; set; }

        public List<TeamMember> TeamMembers { get; set; }
    }
}