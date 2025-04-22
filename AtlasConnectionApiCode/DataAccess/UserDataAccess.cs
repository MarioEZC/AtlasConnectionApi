using AtlasConnectionApiCode.Model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AtlasConnectionApiCode.DataAccess
{
    public class UserDataAccess
    {
        private readonly IMongoCollection<UserModel> _collection;
        private readonly string _collectionName = "User";

        public UserDataAccess(IOptions<MongoDbSetting> mongoSettings)
        {
            var mongoClient = new MongoClient(mongoSettings.Value.ConnectionUri);
            var mongoDataBase = mongoClient.GetDatabase(mongoSettings.Value.DataBaseName);
            _collection = mongoDataBase.GetCollection<UserModel>(_collectionName);
        }

        public async Task<List<UserModel>> GetAsync() => await _collection.Find(_ => true).ToListAsync();
        public async Task<UserModel?> GetAsync(ObjectId id) => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(UserModel user) => await _collection.InsertOneAsync(user);
        public async Task UpdateAsync(ObjectId id, UserModel user) => await _collection.ReplaceOneAsync(x => x.Id == id, user);
        public async Task RemoveAsync(ObjectId id) => await _collection.DeleteOneAsync(x => x.Id == id);
    }


}
