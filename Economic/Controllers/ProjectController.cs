using Microsoft.AspNetCore.Mvc;
using Economic.Data.Repositories;
using Economic.Models;
using Economic.Services;
using AutoMapper;
using System.Threading.Tasks;
using Economic.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Economic.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
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