using AtlasConnectionApiCode.Model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AtlasConnectionApiCode.DataAccess
{
    public class UserDataAccess
    {
        public readonly IMongoCollection<UserModel> _userCollection;

        public UserDataAccess(IOptions<MongoDbSetting> mongoSettings)
        {
            var mongoClient = new MongoClient(mongoSettings.Value.ConnectionUri);
            var mongoDataBase = mongoClient.GetDatabase(mongoSettings.Value.DataBaseName);
            _userCollection = mongoDataBase.GetCollection<UserModel>(mongoSettings.Value.CollectionNameUser);
        }

        public async Task<List<UserModel>> GetAsync() => await _userCollection.Find(_ => true).ToListAsync();
        public async Task<UserModel?> GetAsync(ObjectId id) => await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(UserModel user) => await _userCollection.InsertOneAsync(user);
        public async Task UpdateAsync(ObjectId id, UserModel user) => await _userCollection.ReplaceOneAsync(x => x.Id == id, user);
        public async Task RemoveAsync(ObjectId id) => await _userCollection.DeleteOneAsync(x => x.Id == id);


    }


}
