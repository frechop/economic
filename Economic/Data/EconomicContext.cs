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
        public DbSet<Freelancer> Freelancers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
           .HasOne(p => p.Blog)
           .WithMany(b => b.Posts)
           .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(builder);

        }
    }
}
