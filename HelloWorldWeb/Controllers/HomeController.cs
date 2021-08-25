﻿// <copyright file="HomeController.cs" company="Principal33">
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

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ITeamService teamService;
        private readonly ITimeService timeService;

        public HomeController(ILogger<HomeController> logger, ITeamService teamService, ITimeService timeService)
        {
            this.logger = logger;
            this.teamService = teamService;
            this.timeService = timeService;
        }

        [HttpGet]
        public int GetCount()
        {
            return this.teamService.GetTeamInfo().TeamMembers.Count;
        }

        [HttpPost]
        public int AddTeamMember(string name)
        {
            TeamMember member = new TeamMember();
            member.Name = name;
            return this.teamService.AddTeamMember(member);
        }

        [HttpDelete]
        public void RemoveMember(int id)
        {
            teamService.RemoveMember(id);
        }

        [HttpPost]
        public void UpdateMemberName(int memberId, String name)
        {
            teamService.UpdateMemberName(memberId, name);
        }

        public IActionResult Index()
        {
             return this.View(this.teamService.GetTeamInfo());
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public IActionResult Chat()
        {
            return this.View();
        }
    }
}
