using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VisualScripting.Services.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string Firstname { get; set; }

        [BsonRequired]
        public string Lastname { get; set; }

        public Address Address { get; set; }

    }
}
