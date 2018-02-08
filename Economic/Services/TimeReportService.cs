using Economic.Data;
using Economic.Data.Entities;
using Economic.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Economic.Services
{
    public class TimeReportService : ITimeReportService
    {
        private readonly EconomicContext _ctx;
        private readonly ITimeReportRepository _timeReportRepository;
        private readonly IProjectService _projectService;

        public TimeReportService(EconomicContext context, ITimeReportRepository timeReportRepository, IProjectService projectService)
        {
            _ctx = context ?? throw new ArgumentNullException(nameof(context));
            _timeReportRepository = timeReportRepository ?? throw new ArgumentNullException(nameof(timeReportRepository));
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        }

        public async Task<IEnumerable<TimeReport>> GetReportsByProjectIdAsync(long projectId)
        {
            return await _timeReportRepository.GetReportsByProjectIdAsync(projectId);
        }

        public async Task<IEnumerable<TimeReport>> GetReportsForInvoiceAsync(long projectId)
        {
            var reportsForInvoice = await _timeReportRepository.GetNotSubmittedReportsAsync(projectId);
            await _timeReportRepository.MarkReportsAsSubmittedAsync(reportsForInvoice);
            await _ctx.SaveChangesAsync();
            return reportsForInvoice;
        }

        public async Task AddTimeReportAsync(TimeReport timeReport)
        {
            using (_ctx)
            {
                await _timeReportRepository.AddAsync(timeReport);
                await UpdateProjectTimeAsync(timeReport.HoursSpent, timeReport.ProjectId);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task UpdateTimeReportAsync(TimeReport timeReport)
        {
            using (_ctx)
            {
                var oldReport = await _timeReportRepository.GetAsync(timeReport.Id);
                var timeDifference = oldReport.HoursSpent - timeReport.HoursSpent;
                oldReport.HoursSpent = timeReport.HoursSpent;
                await UpdateProjectTimeAsync(timeDifference, oldReport.ProjectId);
                _timeReportRepository.Update(oldReport);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task UpdateProjectTimeAsync(int hoursSpent, long projectId)
        {
            var project = await _projectService.GetProjectByIdAsync(projectId);
            project.HoursSpent += hoursSpent;
        }

        public async Task DeleteTimeReportAsync(long timeReportId)
        {
            var report = await _timeReportRepository.GetAsync(timeReportId);
            _timeReportRepository.Delete(report);
            await _ctx.SaveChangesAsync();
        }

        public async Task<TimeReport> GetReportByIdAsync(long reportId)
        {
            return await _timeReportRepository.GetAsync(reportId);
        }
    }
}
