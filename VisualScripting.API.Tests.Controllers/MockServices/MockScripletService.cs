using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisualScripting.API.Common.Settings;
using VisualScripting.Services.Contracts;
using VisualScripting.Services.Model;

namespace VisualScripting.API.Tests.Controllers.MockServices
{
    public class MockScripletService : IScripletService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;

        public MockScripletService(IOptions<AppSettings> settings, IMapper mapper)
        {
            _settings = settings?.Value;
            _mapper = mapper;
        }

        public async Task<Scriplet> CreateAsync(Scriplet scriplet)
        {
            return scriplet;
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Scriplet> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Scriplet scriplet)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFieldsAsync(string id, Dictionary<string, string> changes)
        {
            throw new NotImplementedException();
        }
    }
}
