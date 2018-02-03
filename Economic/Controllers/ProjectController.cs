using Microsoft.AspNetCore.Mvc;
using Economic.Data.Repositories;
using Economic.Models;
using Economic.Services;
using AutoMapper;
using System.Threading.Tasks;
using Economic.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

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
            _userManager = userManager;
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreateProject()
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
                project.FreelancerId = (await _userManager.GetUserAsync(User)).FreelancerId;
                await _projectService.AddProjectAsync(project);
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}