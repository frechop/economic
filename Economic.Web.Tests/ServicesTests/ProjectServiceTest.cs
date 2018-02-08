using Economic.Data;
using Economic.Data.Entities;
using Economic.Data.Repositories;
using Economic.Services;
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
            var context = Substitute.For<EconomicContext>();
            var repository = Substitute.For<IProjectRepository>();

        }

        [Fact]
        public void AddPayment()
        {
            service.AddProjectAsync(new Project());

            _repository.Received(1);
        }
    }
}
