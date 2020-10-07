using AutoMapper;
using VisualScripting.API.Common.Settings;
using VisualScripting.Services.Contracts;
using VisualScripting.Services.Model;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace VisualScripting.Services
{
    public class UserService : IUserService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<User> _users;

        public UserService(IOptions<AppSettings> settings, IMapper mapper)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("VisualScriptingDb");

            _users = database.GetCollection<User>("Users");
            _settings = settings?.Value;
            _mapper = mapper;
        }

        public async Task<User> CreateAsync(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var result = _users.ReplaceOne(u => u.Id.Equals(user.Id), user);
            if (result.IsAcknowledged && result.IsModifiedCountAvailable && result.ModifiedCount > 0)
                return true;

            return false;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = _users.DeleteOne(user => user.Id.Equals(id));
            if (result.IsAcknowledged && result.DeletedCount > 0)
                return true;

            return false;
        }

        public async Task<User> GetAsync(string id)
        {
            return _users.Find(user => user.Id.Equals(id)).FirstOrDefault();
        }
    }
}
