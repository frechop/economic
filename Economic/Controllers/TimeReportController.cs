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
using Microsoft.AspNetCore.NodeServices;
using System.Net.Http;

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
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
            _timeReportService = timeReportService ?? throw new ArgumentNullException(nameof(timeReportService));
            _mapper = mapper ?? throw new ArgumentNullException((nameof(mapper)));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> TimeReports(long selectedProjectId = 0)
        {
            var userId = (await _userManager.GetUserAsync(User)).Id;
            var allProjects = await _projectService.GetAllProjectsByUserIdAsync(userId);
            var projectsViewModels = _mapper.Map<IEnumerable<ProjectViewModel>>(allProjects);
            var projectNamesWithIds = projectsViewModels.ToDictionary(x => x.Name, x => x.Id);
            var overViewModel = new TimeReportsOverviewViewModel();

            foreach (long projectId in projectNamesWithIds.Values)
            {
                var timeReports = await _timeReportService.GetReportsByProjectIdAsync(projectId);
                var reportViews = _mapper.Map<IEnumerable<TimeReportViewModel>>(timeReports);

                if (reportViews.Count() > 0)
                {
                    overViewModel.ProjectToReportsDictionary.Add(projectId, reportViews);
                }
            }

            overViewModel.ProjectNamesWithIds = projectNamesWithIds;
            overViewModel.SelectedProject = selectedProjectId;
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
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();

                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var timeReports = await _timeReportService.GetReportsByProjectIdAsync(projectId);

                if (!string.IsNullOrEmpty(searchValue))
                {
                    timeReports = timeReports.Where(m => m.Description.Contains(searchValue));
                }

                recordsTotal = timeReports.Count();
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
        public async Task<IActionResult> Edit(long timeReportId)
        {
            var timeReport = await _timeReportService.GetReportByIdAsync(timeReportId);
            var model = _mapper.Map<TimeReportViewModel>(timeReport);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(TimeReportViewModel model)
        {
            if (ModelState.IsValid)
            {
                var timeReport = _mapper.Map<TimeReport>(model);
                await _timeReportService.UpdateTimeReportAsync(timeReport);
                return RedirectToAction("TimeReports", new { selectedProjectId = model.ProjectId });
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> Delete(long timeReportId)
        {
            await _timeReportService.DeleteTimeReportAsync(timeReportId);

            return Json(data: "Deleted");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyAction([FromServices] INodeServices nodeServices)
        {

            HttpClient client = new HttpClient();
            var htmlContent = await client.GetStringAsync($"http://{Request.Host}/TimeReport/TimeReports/1");

            var result = await nodeServices.InvokeAsync<byte[]>("./pdf", htmlContent);

            HttpContext.Response.ContentType = "application/pdf";

            string filename = @"report.pdf";
            HttpContext.Response.Headers.Add("x-filename", filename);
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "x-filename");
            HttpContext.Response.Body.Write(result, 0, result.Length);
            return new ContentResult();
        }
    }
}