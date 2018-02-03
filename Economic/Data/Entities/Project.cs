using System;

namespace Economic.Data.Entities
{
    public class Project
    {
        public long Id { get; set; }

        public string Name { get; set; }
  
        public long FreelancerId { get; set; }

        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal PricePerHour { get; set; }

        public int HoursSpent { get; set; }

        public int EstimatedTime { get; set; }

        public string ClientName { get; set; }
    }
}
