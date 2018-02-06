using Microsoft.AspNetCore.Mvc;
using Economic.Data.Repositories;
using Economic.Models;
using Economic.Services;
using AutoMapper;
using System.Threading.Tasks;
using Economic.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace Economic.Controllers
{
    public class ProjectController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(
                    UserManager<User> userManager, IProjectService projectService, IMapper mapper)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> CreateProject()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                Project project = _mapper.Map<Project>(projectViewModel);
                project.UserGUID = (await _userManager.GetUserAsync(User)).Id;
                project.StartDate = DateTime.Now;
                await _projectService.AddProjectAsync(project);
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ProjectsDashboard()
        {
            var FreelancerId = (await _userManager.GetUserAsync(User)).Id;

            var allProjects = await _projectService.GetAllProjectsByUserIdAsync(FreelancerId);
            var projectsViewModels = _mapper.Map<IEnumerable<ProjectViewModel>>(allProjects);
            
            return View(projectsViewModels);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}