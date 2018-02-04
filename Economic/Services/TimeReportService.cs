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
        private readonly ITimeReportRepository _timeReportRepository;
        private readonly IProjectRepository _projectRepository;

        public TimeReportService(ITimeReportRepository timeReportRepository, IProjectRepository projectRepository)
        {
            _timeReportRepository = timeReportRepository ?? throw new ArgumentNullException(nameof(timeReportRepository));
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        }

        public async Task<IEnumerable<TimeReport>> GetReportsByProjectIdAsync(long projectId)
        {
            return await _timeReportRepository.GetReportsByProjectIdAsync(projectId);
        }

        public async Task AddTimeReportAsync(TimeReport timeReport)
        {
            await _timeReportRepository.AddAsync(timeReport);
        }

        public async Task UpdateTimeReportAsync(TimeReport timeReport)
        {
            _timeReportRepository.Update(timeReport);
        }
    }
}
