using Economic.Data;
using Economic.Data.Entities;
using Economic.Data.Repositories;
using Economic.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Economic.Web.Tests.ServicesTests
{
    public class ProjectServiceTest
    {
        private readonly IProjectRepository _repository;
        private readonly EconomicContext _context;

        private ProjectService service;

        public ProjectServiceTest()
        {
            _repository = Substitute.For<IProjectRepository>();
            var dbContextOptions = new DbContextOptionsBuilder();
            dbContextOptions.UseInMemoryDatabase();
            _context = new EconomicContext(dbContextOptions.Options);

            service = new ProjectService(_repository, _context);
        }

        [Fact]
        public void Constructor_ArgumentsAreNull_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new ProjectService(null, _context));
            Assert.Throws<ArgumentNullException>(() => new ProjectService(_repository, null));
        }


        [Fact]
        public async Task AddProject_CallsRepository()
        {
            // arrange
            var project = new Project();

            // act
            await service.AddProjectAsync(project);

            // asser
            _repository.Received(1).AddAsync(project);
        }

        [Fact]
        public async Task UpdateProject_CallsRepository()
        {
            // arrange
            var project = new Project();

            // act
            await service.UpdateProjectAsync(project);

            // assert
            _repository.Received(1).Update(project);
        }

        [Fact]
        public async Task GetProjectById_CallsRepository()
        {
            // arrange
            long projectId = new long();
            // act & assert
            await service.GetProjectByIdAsync(projectId);
            await _repository.Received(1).GetAsync(projectId);
        }

        [Fact]
        public async Task GetProjectByIdasync_CallsReposti()
        {
            // arrange
            string userId = "userId";

            // act & assert
            await service.GetAllProjectsByUserIdAsync(userId);

            await _repository.Received(1).GetProjectsByUserIdAsync(userId);
        }
    }
}
