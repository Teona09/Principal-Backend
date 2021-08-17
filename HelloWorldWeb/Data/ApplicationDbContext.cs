using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HelloWorldWeb.Models;

namespace HelloWorldWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HelloWorldWeb.Models.Skill> Skill { get; set; }

        public DbSet<HelloWorldWeb.Models.TeamMember> TeamMembers { get; set; }
    }
}
