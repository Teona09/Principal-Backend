using HelloWorldWeb.Data;
using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;

        public DbTeamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddTeamMember(string name)
        {
            TeamMember teamMember = new TeamMember() { Name = name };
            _context.Add(teamMember);
            _context.SaveChanges();
            return teamMember.Id;
        }

        public TeamInfo GetTeamInfo()
        {
            TeamInfo teamInfo = new TeamInfo();
            teamInfo.Name = "Mock team";
            teamInfo.TeamMembers = _context.TeamMembers.ToList();
            return teamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            foreach (TeamMember member in _context.TeamMembers)
            {
                if (member.Id == id)
                {
                    return member;
                }
            }

            return null;
        }

        public void RemoveMember(int id)
        {
            var teamMember = _context.TeamMembers.Find(id);
            _context.TeamMembers.Remove(teamMember);
            _context.SaveChanges();
        }

        public void UpdateMemberName(int memberId, string name)
        {
            TeamMember teamMember = GetTeamMemberById(memberId);
            if (teamMember == null)
            {
                // object not found
                throw new NullReferenceException("no object with this id");
            }

            teamMember.Name = name;
            _context.Update(teamMember);
            _context.SaveChanges();
        }
    }
}
