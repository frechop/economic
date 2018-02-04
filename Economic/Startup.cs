using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Economic.Data;
using Microsoft.EntityFrameworkCore;
using Economic.Data.Repositories;
using Economic.Data.Mapping;
using Economic.Services;
using Economic.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Economic
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddIdentity<User, IdentityRole>().
                AddEntityFrameworkStores<EconomicContext>().
                AddDefaultTokenProviders();
            services.AddSingleton(AutoMapperFactory.CreateAndConfigure());
            services.AddDbContext<EconomicContext>(options => options.UseSqlite("Data Source = Economic.db", x => x.SuppressForeignKeyEnforcement()));
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITimeReportRepository, TimeReportRepository>();
            services.AddScoped<ITaskEntityRepository, TaskEntityRepository>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ITaskEntityService, TaskEntityService>();
            services.AddTransient<ITimeReportService, TimeReportService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
