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
        private readonly ITimeReportService _timeReportService;
        private readonly IMapper _mapper;

        public TimeReportController(UserManager<User> userManager,
            IProjectService projectService,
            ITimeReportService timeReportService,
            IMapper mapper)
        {
            _userManager = userManager;
            _projectService = projectService;
            _timeReportService = timeReportService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> TimeReports()
        {
            var FreelancerId = (await _userManager.GetUserAsync(User)).Id;
            var allProjects = await _projectService.GetAllProjectsByUserIdAsync(FreelancerId);
            var projectsViewModels = _mapper.Map<IEnumerable<ProjectViewModel>>(allProjects);
            var projectNamesWithIds = projectsViewModels.ToDictionary(x => x.Name, x => x.Id);
            var overViewModel = new TimeReportsOverviewViewModel();
            foreach (long projectId in projectNamesWithIds.Values)
            {
                var reports = await _timeReportService.GetReportsByProjectIdAsync(projectId);
                var reportViews = _mapper.Map<IEnumerable<TimeReportViewModel>>(reports);
                if (reportViews.Count() > 0)
                {
                    overViewModel.ProjectToReportsDictionary.Add(projectId, reportViews);
                }
            }

            overViewModel.ProjectNamesWithIds = projectNamesWithIds;
            return View(overViewModel);

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTimeReport(TimeReportsOverviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                var timeReport = _mapper.Map<TimeReport>(model);
                timeReport.CreationDate = DateTime.Now;
                timeReport.ProjectId = model.SelectedProject;
                await _timeReportService.AddTimeReportAsync(timeReport);
                return RedirectToAction("TimeReports");
            }
            return View();
        }


        public async Task<IActionResult> LoadData(long projectId)
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();

                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data  
                var timeReports = await _timeReportService.GetReportsByProjectIdAsync(projectId);

                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    timeReports = timeReports.Where(m => m.Description.Contains(searchValue));
                }

                //total number of rows count   
                recordsTotal = timeReports.Count();
                //Paging   
                var data = timeReports.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(long TimeReportId)
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(TimeReportViewModel model)
        {
            return View();
        }

    }
}