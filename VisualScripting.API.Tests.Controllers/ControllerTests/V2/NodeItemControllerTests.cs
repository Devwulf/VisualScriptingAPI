using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
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
    public class NodeItemControllerTests : TestBase
    {
        NodeItemController _controller;

        public NodeItemControllerTests() : base()
        {
            var settings = _serviceProvider.GetRequiredService<IOptions<AppSettings>>();
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            var businessService = new MockScripletService(settings, mapper);

            _controller = new NodeItemController(businessService, mapper);
        }

        [TestMethod]
        public async Task CreateNodeItem_Nominal_OK()
        {
            //Simple test
            var scriplet = await _controller.CreateNodeItem("scripletId1", new NodeItemCreationRequest
            {
                NodeItem = new NodeItem { Id = 0, X = 0, Y = 0, SchemaId = "Schema" },
                Date = DateTime.Now
            });

            Assert.IsNotNull(scriplet);
        }
    }
}
