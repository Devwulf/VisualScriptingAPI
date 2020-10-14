using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VisualScripting.API.Common.Settings;
using VisualScripting.Services.Contracts;

namespace VisualScripting.API.Tests.Controllers.ServiceTests
{
    [TestClass]
    public class UserServiceTest : TestBase
    {
        private readonly IUserService _service;

        public UserServiceTest() : base()
        {
            var settings = _serviceProvider.GetRequiredService<IOptions<AppSettings>>();
            var mapper = _serviceProvider.GetRequiredService<IMapper>();

            _service = _serviceProvider.GetRequiredService<IUserService>();
        }
    }
}
