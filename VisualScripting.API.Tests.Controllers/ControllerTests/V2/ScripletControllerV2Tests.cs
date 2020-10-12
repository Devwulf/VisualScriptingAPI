using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisualScripting.API.Common.Settings;
using VisualScripting.API.Controllers.V2;
using VisualScripting.API.DataContracts;
using VisualScripting.API.DataContracts.Requests;
using VisualScripting.API.Tests.Controllers.MockServices;

namespace VisualScripting.API.Tests.Controllers.ControllerTests.V2
{
    [TestClass]
    public class ScripletControllerV2Tests : TestBase
    {
        ScripletControllerV2 _controller;

        public ScripletControllerV2Tests() : base()
        {
            var settings = _serviceProvider.GetRequiredService<IOptions<AppSettings>>();
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            var businessService = new MockScripletService(settings, mapper);

            _controller = new ScripletControllerV2(businessService, mapper);
        }

        [TestMethod]
        public async Task CreateScriplet_Nominal_OK()
        {
            //Simple test
            var scriplet = await _controller.CreateScriplet(new ScripletCreationRequest
            {
                Scriplet = new Scriplet { Id = "U1", Name = "Name1", Description = "Description1" },
                Date = DateTime.Now
            });

            Assert.IsNotNull(scriplet);
        }

        [TestMethod]
        public async Task ScripletParam_InvalidScriplet()
        {
            var nameNull = new Scriplet { Id = "U1", Name = null, Description = "Description1" };
            var nameEmpty = new Scriplet { Id = "U1", Name = "", Description = "Description1" };

            Assert.IsFalse(nameNull.IsValid());
            Assert.IsFalse(nameEmpty.IsValid());

            var descriptionNull = new Scriplet { Id = "U1", Name = "Name1", Description = null };
            var descriptionEmpty = new Scriplet { Id = "U1", Name = "Name1", Description = "" };

            Assert.IsFalse(descriptionNull.IsValid());
            Assert.IsFalse(descriptionEmpty.IsValid());
        }
    }
}
