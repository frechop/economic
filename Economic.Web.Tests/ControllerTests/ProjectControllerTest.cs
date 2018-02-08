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
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

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
            var optionsAccessor = new Mock<IOptions<IdentityOptions>>();
            var hasher = new Mock<IPasswordHasher<User>>();
            var validator = new Mock<IEnumerable<UserValidator<User>>>();
            var passwordValidator = new Mock<IEnumerable<IPasswordValidator<User>>>();
            var normalizer = new Mock<ILookupNormalizer>();
            var describer = new Mock<IdentityErrorDescriber>();
            var serviceprovider = new Mock<IServiceProvider>();
            var logger = new Mock<ILogger<UserManager<User>>>();
            _userManager = new UserManager<User>(mockUserStore.Object,optionsAccessor.Object, hasher.Object, validator.Object,passwordValidator.Object, normalizer.Object,describer.Object, serviceprovider.Object,logger.Object);
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
