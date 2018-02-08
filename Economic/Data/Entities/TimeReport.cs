using System;

namespace Economic.Data.Entities
{
    public class TimeReport
    {
        public long Id { get; set; }

        public long ProjectId { get; set; }

        public long? TaskId { get; set; }

        public DateTime CreationDate { get; set; }

        public int HoursSpent { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool Submitted { get; set; }
    }
}
