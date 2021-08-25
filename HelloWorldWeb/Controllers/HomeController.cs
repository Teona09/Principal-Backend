// <copyright file="HomeController.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Controllers
{
    using System;
    using System.Diagnostics;
    using HelloWorldWeb.Models;
    using HelloWorldWeb.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ITeamService teamService;
        private readonly ITimeService timeService = null;
        private readonly IBroadcastService broadcastService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger"> Necesary parameter for the superclass.</param>
        /// <param name="teamService"> Team service parameter.</param>
        /// <param name="timeService"> Time service parameter.</param>
        /// <param name="broadcastService"> Boardcast service parameter.</param>
        public HomeController(ILogger<HomeController> logger, ITeamService teamService, ITimeService timeService, IBroadcastService broadcastService)
        {
            this.logger = logger;
            this.teamService = teamService;
            this.timeService = timeService;
            this.broadcastService = broadcastService;
        }

        /// <summary>
        /// Get endpoint which returns the number of the team members.
        /// </summary>
        /// <returns> the number of team members.</returns>
        [HttpGet]
        public int GetCount()
        {
            return this.teamService.GetTeamInfo().TeamMembers.Count;
        }

        /// <summary>
        /// Post endpoint to add a new team member.
        /// </summary>
        /// <param name="name"> Name of the new team member.</param>
        /// <returns> New team member id.</returns>
        [HttpPost]
        public int AddTeamMember(string name)
        {
            // TeamMember member = new TeamMember(name, timeService);
            TeamMember member = new TeamMember() { Name = name };
            int newMemberId = this.teamService.AddTeamMember(member);
            broadcastService.NewTeamMemberAdded(member, member.Id);
            return newMemberId;
        }

        /// <summary>
        /// Deletes a member.
        /// </summary>
        /// <param name="id"> id of the team member that has to be deleted.</param>
        [HttpDelete]
        public void RemoveMember(int id)
        {
            teamService.RemoveMember(id);
            this.broadcastService.TeamMemberDeleted(id);
        }

        /// <summary>
        /// Post endpoints to update a team member.
        /// </summary>
        /// <param name="memberId"> id of the team member to be updated.</param>
        /// <param name="name"> new name for the team member.</param>
        [HttpPost]
        public void UpdateMemberName(int memberId, String name)
        {
            teamService.UpdateMemberName(memberId, name);
            this.broadcastService.TeamMemberEdited(memberId, name);
        }

        /// <summary>
        /// Loads the Index page.
        /// </summary>
        /// <returns> Returns an implementation of IActionResult that has the teamInfo properties.</returns>
        public IActionResult Index()
        {
             return this.View(this.teamService.GetTeamInfo());
        }

        /// <summary>
        /// Loads the privacy page.
        /// </summary>
        /// <returns>Returns an implementation of IActionResult.</returns>
        public IActionResult Privacy()
        {
            return this.View();
        }

        /// <summary>
        /// Loads an error page.
        /// </summary>
        /// <returns>Returns an implementation of IActionResult which contains error infomations.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Creates the Chat view.
        /// </summary>
        /// <returns>Returns the chat view.</returns>
        public IActionResult Chat()
        {
            return this.View();
        }
    }
}
