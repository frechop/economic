using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Economic.Services;
using Microsoft.AspNetCore.Identity;
using Economic.Data.Entities;
using Economic.Models;
using Microsoft.AspNetCore.Authorization;

namespace Economic.Controllers
{
    public class TimeReportController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public TimeReportController(UserManager<User> userManager, IProjectService projectService, IMapper mapper)
        {
            _userManager = userManager;
            _projectService = projectService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> TimeReports()
        {
            var FreelancerId = (await _userManager.GetUserAsync(User)).Id;
            var allProjects = await _projectService.GetAllProjectsByUserIdAsync(FreelancerId);
            var projectsViewModels = _mapper.Map<IEnumerable<ProjectViewModel>>(allProjects);


            return View(allProjects);

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}