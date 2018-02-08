using Economic.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Economic.Data.Repositories
{
    public class TimeReportRepository: Repository<TimeReport>, ITimeReportRepository
    {
        public EconomicContext _ctx;
        
        public TimeReportRepository(EconomicContext context) : base(context)
        {
            _ctx = context;
        }

        public async Task<IEnumerable<TimeReport>> GetReportsByProjectIdAsync(long projectId)
        {
            return _ctx.TimeReports.Where(t => t.ProjectId == projectId).ToList();
        }

        public async Task<IEnumerable<TimeReport>> GetNotSubmittedReportsAsync(long projectId)
        {
            return _ctx.TimeReports.Where(t => t.ProjectId == projectId && t.Submitted == false).ToList();
        }

        public async Task MarkReportsAsSubmittedAsync(IEnumerable<TimeReport> timeReports)
        {
            foreach(TimeReport report in timeReports)
            {
                report.Submitted = true;
            }
            _ctx.TimeReports.UpdateRange(timeReports);
        }
    }
}
