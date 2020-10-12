using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisualScripting.API.Common.MongoDB;
using VisualScripting.API.Common.Settings;
using VisualScripting.Services.Contracts;
using VisualScripting.Services.Model;

namespace VisualScripting.Services.Services
{
    public class ScripletService : IScripletService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;
        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<Scriplet> _scriplets;

        public ScripletService(IOptions<AppSettings> settings, IMapper mapper, MongoDBClient mongoClient)
        {
            var client = mongoClient.MongoClient;
            var appSettings = settings.Value;
            var database = client.GetDatabase(appSettings.MongoDB.DatabaseName);

            _scriplets = database.GetCollection<Scriplet>("Scriplets");
            _mongoClient = mongoClient.MongoClient;
            _settings = settings?.Value;
            _mapper = mapper;
        }

        public async Task<Scriplet> CreateAsync(Scriplet scriplet)
        {
            await _scriplets.InsertOneAsync(scriplet);
            return scriplet;
        }

        public async Task<bool> UpdateAsync(Scriplet scriplet)
        {
            var result = await _scriplets.ReplaceOneAsync(s => s.Id.Equals(scriplet.Id), scriplet);
            if (result.IsAcknowledged && result.IsModifiedCountAvailable && result.ModifiedCount > 0)
                return true;

            return false;
        }

        public async Task<bool> UpdateSetAsync(string id, Dictionary<string, object> changes)
        {
            var updateValues = new List<UpdateDefinition<Scriplet>>();

            foreach (var pair in changes)
                updateValues.Add(Builders<Scriplet>.Update.Set(pair.Key.ToLower(), pair.Value));

            var update = Builders<Scriplet>.Update.Combine(updateValues);
            var result = await _scriplets.UpdateOneAsync(s => s.Id.Equals(id), update);
            if (result.IsAcknowledged && result.IsModifiedCountAvailable && result.ModifiedCount > 0)
                return true;

            return false;
        }

        public async Task<bool> UpdateUnsetAsync(string id, Dictionary<string, object> changes)
        {
            var updateValues = new List<UpdateDefinition<Scriplet>>();

            foreach (var pair in changes)
                updateValues.Add(Builders<Scriplet>.Update.Unset(pair.Key.ToLower()));

            var update = Builders<Scriplet>.Update.Combine(updateValues);
            var result = await _scriplets.UpdateOneAsync(s => s.Id.Equals(id), update);
            if (result.IsAcknowledged && result.IsModifiedCountAvailable && result.ModifiedCount > 0)
                return true;

            return false;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _scriplets.DeleteOneAsync(s => s.Id.Equals(id));
            if (result.IsAcknowledged && result.DeletedCount > 0)
                return true;

            return false;
        }

        public async Task<Scriplet> GetAsync(string id)
        {
            return (await _scriplets.FindAsync(s => s.Id.Equals(id))).FirstOrDefault();
        }
    }
}
