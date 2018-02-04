using Economic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
