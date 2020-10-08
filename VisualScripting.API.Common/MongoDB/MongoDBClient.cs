using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace VisualScripting.API.Common.MongoDB
{
    public class MongoDBClient
    {
        public MongoClient MongoClient { get; private set; }

        public MongoDBClient(string uri)
        {
            MongoClient = new MongoClient(uri);

            var pack = new ConventionPack();
            pack.AddMemberMapConvention("LowerCaseElementName", m => m.SetElementName(m.MemberName.ToLower()));
            ConventionRegistry.Register("Lower Case", pack, t => true);
        }
    }
}
