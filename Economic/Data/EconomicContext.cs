using Economic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Data
{
    public class EconomicContext : DbContext
    {
        public EconomicContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<ProjectEntity> Projects { get; set; }
    }
}
