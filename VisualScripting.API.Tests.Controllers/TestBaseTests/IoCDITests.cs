using System.Threading.Tasks;

using AutoMapper;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VisualScripting.API.Common.Settings;

namespace VisualScripting.API.Tests.Controllers.TestBaseTests
{
    [TestClass]
    public class IoCDITests : TestBase
    {
        [TestMethod]
        public async Task IoC_DI_ServiceProvider_OK()
        {
            Assert.IsNotNull(_serviceProvider);
        }


        [TestMethod]
        public async Task IoC_DI_Mapper_OK()
        {
            Assert.IsNotNull(_serviceProvider);

            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            Assert.IsNotNull(mapper);
        }

        [TestMethod]
        public async Task IoC_DI_LoggerFactory_OK()
        {
            var serviceProvider = _services.BuildServiceProvider();
            Assert.IsNotNull(serviceProvider);

            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            Assert.IsNotNull(loggerFactory);
        }

        [TestMethod]
        public async Task IoC_DI_IOptions_AppSettings_OK()
        {
            var serviceProvider = _services.BuildServiceProvider();
            Assert.IsNotNull(serviceProvider);

            var ioptions = serviceProvider.GetService<IOptions<AppSettings>>();
            Assert.IsNotNull(ioptions);
        }

        [TestMethod]
        public async Task IoC_DI_IOptions_AppSettings_Value_OK()
        {
            var serviceProvider = _services.BuildServiceProvider();
            Assert.IsNotNull(serviceProvider);

            var ioptions = serviceProvider.GetService<IOptions<AppSettings>>();
            Assert.IsNotNull(ioptions);

            var appSettings = ioptions.Value;
            Assert.IsNotNull(appSettings);
        }

        [TestMethod]
        public async Task IoC_DI_IOptions_AppSettings_Value_API_OK()
        {
            var serviceProvider = _services.BuildServiceProvider();
            Assert.IsNotNull(serviceProvider);

            var ioptions = serviceProvider.GetService<IOptions<AppSettings>>();
            Assert.IsNotNull(ioptions);

            var appSettings = ioptions.Value;
            Assert.IsNotNull(appSettings);

            var api = appSettings.API;
            Assert.IsNotNull(api);
        }

        [TestMethod]
        public async Task IoC_DI_IOptions_AppSettings_Value_Swagger_OK()
        {
            var serviceProvider = _services.BuildServiceProvider();
            Assert.IsNotNull(serviceProvider);

            var ioptions = serviceProvider.GetService<IOptions<AppSettings>>();
            Assert.IsNotNull(ioptions);

            var appSettings = ioptions.Value;
            Assert.IsNotNull(appSettings);

            var swagger = appSettings.Swagger;
            Assert.IsNotNull(swagger);
        }

        [TestMethod]
        public async Task IoC_DI_IOptions_AppSettings_Value_MongoDB_OK()
        {
            var serviceProvider = _services.BuildServiceProvider();
            Assert.IsNotNull(serviceProvider);

            var ioptions = serviceProvider.GetService<IOptions<AppSettings>>();
            Assert.IsNotNull(ioptions);

            var appSettings = ioptions.Value;
            Assert.IsNotNull(appSettings);

            var mongoDb = appSettings.MongoDB;
            Assert.IsNotNull(mongoDb);
        }
    }
}
