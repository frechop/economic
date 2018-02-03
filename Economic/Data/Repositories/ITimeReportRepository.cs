using Economic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Data.Repositories
{
    public interface ITimeReportRepository : IRepository<TimeReport>
    {
        Task<IEnumerable<TimeReport>> GetReportsByProjectIdAsync(long projectId);
    }
}
