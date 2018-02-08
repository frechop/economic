using Economic.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Economic.Data.Repositories
{
    public interface ITimeReportRepository : IRepository<TimeReport>
    {
        Task<IEnumerable<TimeReport>> GetReportsByProjectIdAsync(long projectId);

        Task<IEnumerable<TimeReport>> GetNotSubmittedReportsAsync(long projectId);

        Task MarkReportsAsSubmittedAsync(IEnumerable<TimeReport> reports);
    }
}
