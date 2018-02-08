using Economic.Data;
using Economic.Data.Entities;
using Economic.Data.Repositories;
using Economic.Services;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Economic.Web.Tests.ServicesTests
{
    public class TimeReportServiceTest
    {
        private readonly EconomicContext _context;
        private readonly ITimeReportRepository _repository;
        private readonly IProjectService _projectService;
        private readonly TimeReportService _timeReportService;

        public TimeReportServiceTest()
        {
            _repository = Substitute.For<ITimeReportRepository>();
            _projectService = Substitute.For<IProjectService>();
            var dbContextOptions = new DbContextOptionsBuilder();
            dbContextOptions.UseInMemoryDatabase();
            _context = new EconomicContext(dbContextOptions.Options);

            _timeReportService = new TimeReportService(_context, _repository , _projectService);

        }

        [Fact]
        public void Constructor_ArgumentsAreNull_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new TimeReportService(null, _repository, _projectService));
            Assert.Throws<ArgumentNullException>(() => new TimeReportService(_context, null, _projectService));
            Assert.Throws<ArgumentNullException>(() => new TimeReportService(_context, _repository, null));

        }

        [Fact]
        public async Task GetReports_ByProjectIDAsync_CallsRepository()
        {
            // arrange
            long projectId = new long();

            // act
            await _timeReportService.GetReportsByProjectIdAsync(projectId);

            // assert
            _repository.Received(1).GetReportsByProjectIdAsync(projectId);
        }

        [Fact]
        public async Task GetReportsForInvoiceAsync_Calls_Rep_Mark_Submitted()
        {
            // arrange
            long projectId = new long();
            
            // act
            await _timeReportService.GetReportsForInvoiceAsync(projectId);

            // assert
            await _repository.Received(1).GetNotSubmittedReportsAsync(projectId);
            await _repository.ReceivedWithAnyArgs(1).MarkReportsAsSubmittedAsync(new List<TimeReport>());
        }

        [Fact]
        public async Task UpdateTimeReport_UpdatesProject()
        {
            // arrange
            TimeReport report = new TimeReport();

            // act
            await _timeReportService.UpdateTimeReportAsync(report);

            // assert
            _repository.Update(report);
        }

        [Fact]
        public async Task UpdatProjectTime_CallsProjectService()
        {
            // arrange 
            int hoursSpent = 1;
            long projectId = 1;

            // act
            await _timeReportService.UpdateProjectTimeAsync(hoursSpent, projectId);

            // assert
            _projectService.Received(1).GetProjectByIdAsync(projectId);
        }
    }
}
