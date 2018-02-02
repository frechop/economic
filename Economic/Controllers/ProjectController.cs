using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Economic.Data.Repositories;

namespace Economic.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _repository;
        
        public ProjectController(IProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}