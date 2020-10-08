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
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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

        [TestMethod]
        public async Task CreateUser_UserParam_InvalidUser()
        {
            var firstNameNullResults = new List<ValidationResult>();
            var firstNameNull = new User { Id = "U1", Firstname = null, Lastname = "Lastname 1" };

            var firstNameEmptyResults = new List<ValidationResult>();
            var firstNameEmpty = new User { Id = "U1", Firstname = "", Lastname = "Lastname 1" };

            bool firstNameNullResult = Validator.TryValidateObject(firstNameNull, new System.ComponentModel.DataAnnotations.ValidationContext(firstNameNull), firstNameNullResults);
            bool firstNameEmptyResult = Validator.TryValidateObject(firstNameEmpty, new System.ComponentModel.DataAnnotations.ValidationContext(firstNameEmpty), firstNameEmptyResults);

            Assert.IsFalse(firstNameNullResult);
            Assert.IsFalse(firstNameEmptyResult);

            var lastNameNullResults = new List<ValidationResult>();
            var lastNameNull = new User { Id = "U1", Firstname = "Firstname 1", Lastname = null };

            var lastNameEmptyResults = new List<ValidationResult>();
            var lastNameEmpty = new User { Id = "U1", Firstname = "Firstname 1", Lastname = "" };

            bool lastNameNullResult = Validator.TryValidateObject(lastNameNull, new System.ComponentModel.DataAnnotations.ValidationContext(firstNameNull), firstNameNullResults);
            bool lastNameEmptyResult = Validator.TryValidateObject(lastNameEmpty, new System.ComponentModel.DataAnnotations.ValidationContext(firstNameEmpty), firstNameEmptyResults);

            Assert.IsFalse(lastNameNullResult);
            Assert.IsFalse(lastNameEmptyResult);
        }
    }
}
