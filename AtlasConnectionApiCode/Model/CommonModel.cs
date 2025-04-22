using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AtlasConnectionApiCode.Model
{
    public class CommonModel
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.Empty;
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
