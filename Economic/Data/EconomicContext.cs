using Economic.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Data
{
    public class EconomicContext : IdentityDbContext<User>
    {
        public EconomicContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<TimeReport> TimeReports { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
