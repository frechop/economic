using Economic.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Economic.Services
{
    public class InvoiceGenerationService : IInvoiceGenerationService
    {
        public string GenerateInvoiceAsString(IEnumerable<TimeReport> reportsForInvoice)
        {
            var invoiceAsString = new StringBuilder();

            string header = "<h1><center>Invoice</center></h1>";
            string newLine = "<br/><br/>";
            invoiceAsString.Append(header);
            invoiceAsString.Append(newLine);

            foreach(TimeReport report in reportsForInvoice)
            {
                invoiceAsString.Append("<h2>TaskID:" + report.Id +
                                       "  Hours Spent: " + report.HoursSpent +
                                       "  Price: " + report.Price + "$</h2>");
            }
            invoiceAsString.Append(newLine);
            invoiceAsString.Append("<h1>Total: " + reportsForInvoice.Sum(x => x.Price) + "$</h1>");
            return invoiceAsString.ToString();
        }
    }
}
