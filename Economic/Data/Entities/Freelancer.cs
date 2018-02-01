using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Data.Entities
{
    public class Freelancer
    {
        public long Id { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
