using AutoMapper;
using VisualScripting.API.Common.Settings;
using VisualScripting.Services.Contracts;
using VisualScripting.Services.Model;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

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
            var pack = new ConventionPack();
            pack.AddMemberMapConvention("LowerCaseElementName", m => m.SetElementName(m.MemberName.ToLower()));
            ConventionRegistry.Register("Lower Case", pack, t => true);

            _users = database.GetCollection<User>("Users");
            _settings = settings?.Value;
            _mapper = mapper;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var result = await _users.ReplaceOneAsync(u => u.Id.Equals(user.Id), user);
            if (result.IsAcknowledged && result.IsModifiedCountAvailable && result.ModifiedCount > 0)
                return true;

            return false;
        }

        public async Task<bool> UpdateFieldsAsync(string id, Dictionary<string, string> changes)
        {
            var updateValues = new List<UpdateDefinition<User>>();

            foreach (var pair in changes)
                updateValues.Add(Builders<User>.Update.Set(pair.Key.ToLower(), pair.Value));

            var update = Builders<User>.Update.Combine(updateValues);
            var result = await _users.UpdateOneAsync(user => user.Id.Equals(id), update);
            if (result.IsAcknowledged && result.IsModifiedCountAvailable && result.ModifiedCount > 0)
                return true;

            return false;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _users.DeleteOneAsync(user => user.Id.Equals(id));
            if (result.IsAcknowledged && result.DeletedCount > 0)
                return true;

            return false;
        }

        public async Task<User> GetAsync(string id)
        {
            return (await _users.FindAsync(user => user.Id.Equals(id))).FirstOrDefault();
        }
    }
}
