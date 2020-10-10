using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VisualScripting.API.Common.Settings;

namespace VisualScripting.API.Tests.Controllers.TestBaseTests
{
    [TestClass]
    public class ConfigurationTests : TestBase
    {
        [TestMethod]
        public async Task ConfigurationRoot_OK()
        {
            Assert.IsNotNull(_configurationRoot);
        }

        [TestMethod]
        public async Task AppSettingsIConfiguration_OK()
        {
            Assert.IsNotNull(_configurationRoot);

            var appSettings = _configurationRoot.GetSection(nameof(AppSettings));
            Assert.IsNotNull(appSettings);
        }

        [TestMethod]
        public async Task AppSettings_OK()
        {
            Assert.IsNotNull(_configurationRoot);

            var iConfiguration = _configurationRoot.GetSection(nameof(AppSettings));
            Assert.IsNotNull(iConfiguration);

            var appSettings = iConfiguration.Get<AppSettings>();
            Assert.IsNotNull(appSettings);
        }

        [TestMethod]
        public async Task AppSettings_API_OK()
        {
            Assert.IsNotNull(_configurationRoot);

            var iConfiguration = _configurationRoot.GetSection(nameof(AppSettings));
            Assert.IsNotNull(iConfiguration);

            var appSettings = iConfiguration.Get<AppSettings>();
            Assert.IsNotNull(appSettings);

            var api = appSettings.API;
            Assert.IsNotNull(api);
        }

        [TestMethod]
        public async Task AppSettings_Swagger_OK()
        {
            Assert.IsNotNull(_configurationRoot);

            var iConfiguration = _configurationRoot.GetSection(nameof(AppSettings));
            Assert.IsNotNull(iConfiguration);

            var appSettings = iConfiguration.Get<AppSettings>();
            Assert.IsNotNull(appSettings);

            var swagger = appSettings.Swagger;
            Assert.IsNotNull(swagger);
        }

        [TestMethod]
        public async Task AppSettings_MongoDB_OK()
        {
            Assert.IsNotNull(_configurationRoot);

            var iConfiguration = _configurationRoot.GetSection(nameof(AppSettings));
            Assert.IsNotNull(iConfiguration);

            var appSettings = iConfiguration.Get<AppSettings>();
            Assert.IsNotNull(appSettings);

            var mongoDb = appSettings.MongoDB;
            Assert.IsNotNull(mongoDb);
        }
    }
}
