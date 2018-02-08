using Economic.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Economic.Services
{
    public interface ITimeReportService
    {
        Task<IEnumerable<TimeReport>> GetReportsByProjectIdAsync(long projectId);

        Task<IEnumerable<TimeReport>> GetReportsForInvoiceAsync(long projectId);

        Task AddTimeReportAsync(TimeReport timeReport);

        Task DeleteTimeReportAsync(long timeReportId);

        Task UpdateTimeReportAsync(TimeReport TimeReport);

        Task<TimeReport> GetReportByIdAsync(long reportId);
    }
}
