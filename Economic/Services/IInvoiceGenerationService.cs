using Economic.Data.Entities;
using System.Collections.Generic;

namespace Economic.Services
{
    public interface IInvoiceGenerationService
    {
        string GenerateInvoiceAsString(IEnumerable<TimeReport> reportsForInvoice);
    }
}
