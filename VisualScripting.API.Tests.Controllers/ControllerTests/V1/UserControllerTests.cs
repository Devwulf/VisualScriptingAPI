using AutoMapper;
using VisualScripting.API.Controllers.V1;
using VisualScripting.API.DataContracts.Requests;
using VisualScripting.API.DataContracts;
using VisualScripting.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using VisualScripting.API.Common.Settings;
using VisualScripting.API.Tests.Controllers.MockServices;

namespace VisualScripting.API.Tests.Controllers.ControllerTests.V1
{
    [TestClass]
    public class UserControllerTests : TestBase
    {
        //NOTE: should be replaced by an interface
        UserController _controller;

        public UserControllerTests() : base()
        {
            var settings = _serviceProvider.GetRequiredService<IOptions<AppSettings>>();
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            var businessService = new MockUserService(settings, mapper);
            var loggerFactory = _serviceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<UserController>();

            _controller = new UserController(businessService, mapper, logger);
        }

        [TestMethod]
        public async Task CreateUser_Nominal_OK()
        {
            //Simple test
            var user = await _controller.CreateUser(new UserCreationRequest
            {
                User = new User { Id = "U1", Firstname = "Firstname 1", Lastname = "Lastname 1" },
                Date = DateTime.Now
            });

            Assert.IsNotNull(user);
        }


    }
}
