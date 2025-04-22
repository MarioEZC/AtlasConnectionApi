using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AtlasConnectionApiCode.Model
{
    public class UserModel
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public IEnumerable<Telephonemodel> PhoneNumbers { get; set; } = [];
        public IEnumerable<DirectionModel> Directions { get; set; } = [];
    }

    public class Telephonemodel
    {
        public string Number { get; set; } = string.Empty;
        public string NumberType { get; set; } = string.Empty;
    }

    public class DirectionModel
    {
        public string Direction { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string DirectionType { get; set; } = string.Empty;
    }
}
