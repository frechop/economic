using Economic.Data;
using Economic.Data.Entities;
using Economic.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Services
{
    public class TimeReportService : ITimeReportService
    {
        private readonly EconomicContext _ctx;
        private readonly ITimeReportRepository _timeReportRepository;
        private readonly IProjectRepository _projectRepository;

        public TimeReportService(EconomicContext context, ITimeReportRepository timeReportRepository, IProjectRepository projectRepository)
        {
            _ctx = context;
            _timeReportRepository = timeReportRepository ?? throw new ArgumentNullException(nameof(timeReportRepository));
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        }

        public async Task<IEnumerable<TimeReport>> GetReportsByProjectIdAsync(long projectId)
        {
            return await _timeReportRepository.GetReportsByProjectIdAsync(projectId);
        }

        public async Task AddTimeReportAsync(TimeReport timeReport)
        {
            using (_ctx)
            {
                await _timeReportRepository.AddAsync(timeReport);
            }
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateTimeReportAsync(TimeReport timeReport)
        {
            _timeReportRepository.Update(timeReport);
        }

        public async Task DeleteTimeReportAsync(TimeReport timeReport)
        {
           _timeReportRepository.Delete(timeReport);
        }
    }
}
