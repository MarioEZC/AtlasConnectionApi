namespace AtlasConnectionApiCode.DataAccess
{
    public class MongoDbSetting
    {
        public string ConnectionUri { get; set; } = string.Empty;
        public string DataBaseName { get; set; } = string.Empty;
        public string CollectionNameUser { get; set; } = string.Empty;
    }
}
