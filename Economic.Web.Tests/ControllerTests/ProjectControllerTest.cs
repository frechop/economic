using Economic.Services;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Economic.Data.Entities;
using Economic.Controllers;
using NSubstitute;
using Xunit;
using Economic.Data.Mapping;
using Moq;

namespace Economic.Web.Tests.ControllerTests
{
    public class ProjectControllerTest
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IProjectService _projectService;

        private readonly ProjectController controller;

        public ProjectControllerTest()
        {
            var mockUserStore = new Mock<IUserStore<User>>();

            _userManager = new UserManager<User>(mockUserStore.Object);
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ProjectProfile>());
            _mapper = new Mapper(config);
            _projectService = Substitute.For<IProjectService>();
        }

        [Fact]
        public void Constructor_ArgumentsAreNull_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new ProjectController(null, _projectService, _mapper));
            Assert.Throws<ArgumentNullException>(() => new ProjectController(_userManager, null, _mapper));
            Assert.Throws<ArgumentNullException>(() => new ProjectController(_userManager, _projectService, null));
        }

    }
}
