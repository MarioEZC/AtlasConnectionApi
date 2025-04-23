using MongoDB.Bson;

namespace AtlasConnectionApiCode.Dto.Response
{
    public class FindUserDtoResponse
    {
        public string Id { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public int PhoneCount { get; set; } = 0;
        public int DirectionCount { get; set; } = 0;
    }
}
