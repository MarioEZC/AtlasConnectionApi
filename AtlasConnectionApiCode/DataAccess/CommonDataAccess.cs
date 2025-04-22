using AtlasConnectionApiCode.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AtlasConnectionApiCode.DataAccess
{
    public class CommonDataAccess
    {
        private readonly IMongoCollection<CommonModel> _collection;
        private readonly string _collectionName = "Common";

        public CommonDataAccess(IOptions<MongoDbSetting> mongoSettings)
        {
            var mongoClient = new MongoClient(mongoSettings.Value.ConnectionUri);
            var mongoDataBase = mongoClient.GetDatabase(mongoSettings.Value.DataBaseName);
            _collection = mongoDataBase.GetCollection<CommonModel>(_collectionName);
        }

        public async Task<List<CommonModel>> GetAsync() => await _collection.Find(_ => true).ToListAsync();
    }
}
