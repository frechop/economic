using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Models
{
    public class ProjectViewModel
    {
        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal PricePerHour { get; set; }

        public int HoursSpent { get; set; }

        public int EstimatedTime { get; set; }
    }
}
