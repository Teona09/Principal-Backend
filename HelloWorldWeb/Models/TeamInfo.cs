namespace HelloWorldWeb.Models
{
    using System.Collections.Generic;

    public class TeamInfo
    {
        public string Name { get; set; }

        public List<TeamMember> TeamMembers { get; set; }
    }
}