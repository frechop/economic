using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Models
{
    public class TimeReportsOverviewViewModel
    {
        public IDictionary<long, IEnumerable<TimeReportViewModel>> ProjectToReportsDictionary { get; set; } = new Dictionary<long, IEnumerable<TimeReportViewModel>>();

        public IDictionary<long, IEnumerable<TaskViewModel>> ProjectToTasksDictionary { get; set; } = new Dictionary<long, IEnumerable<TaskViewModel>>();

        public IDictionary<string, long> ProjectNamesWithIds { get; set; } = new Dictionary<string, long>();

        public long SelectedProject { get; set; }

        public long? TaskId { get; set; }

        [Required]
        public int HoursSpent { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string content { get; set; }
    }
}
