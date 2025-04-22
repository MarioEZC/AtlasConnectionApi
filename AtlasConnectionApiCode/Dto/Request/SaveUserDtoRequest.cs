using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AtlasConnectionApiCode.Dto.Request
{
    public class SaveUserDtoRequest
    {
        public ObjectId? Id { get; set; } = ObjectId.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }

        public List<PhoneNumber>? PhoneNumbers { get; set; } = null;
        public List<Direction>? Directions { get; set; } = null;
    }

    public class PhoneNumber
    {
        public string Number { get; set; } = string.Empty;
        public string NumberType { get; set; } = string.Empty;
    }

    public class Direction
    {
        public string Address { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string DirectionType { get; set; } = string.Empty;
    }
}
