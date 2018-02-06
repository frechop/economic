using System;
using System.ComponentModel.DataAnnotations;

namespace Economic.Models
{
    public class TimeReportViewModel
    {
        public long Id { get; set; }

        public long ProjectId { get; set; }

        public long? TaskId { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public int HoursSpent { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool Submitted { get; set; }
    }
}
