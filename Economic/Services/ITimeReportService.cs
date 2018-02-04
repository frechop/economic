using Economic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Services
{
    public interface ITimeReportService
    {
        Task<IEnumerable<TimeReport>> GetReportsByProjectIdAsync(long projectId);

        Task AddTimeReportAsync(TimeReport timeReport);
    }
}
