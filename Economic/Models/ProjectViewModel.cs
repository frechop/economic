using System;
using System.ComponentModel.DataAnnotations;

namespace Economic.Models
{
    public class ProjectViewModel
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string UserGUID { get; set; }

        [Required]
        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal PricePerHour { get; set; }

        public int HoursSpent { get; set; }

        [Required]
        public int EstimatedTime { get; set; }

        public string ClientName { get; set; }

        public string Description { get; set; }
    }
}
