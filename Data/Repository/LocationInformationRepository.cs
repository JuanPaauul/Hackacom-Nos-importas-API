using appPrevencionRiesgos.Data.Entities;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace appPrevencionRiesgos.Data.Repository
{
    public class LocationInformationRepository : ILocationInformationRepository
    {
        internal MongoDbContext _dbContext = new MongoDbContext();
        private IMongoCollection<LocationEntity> collection;
        public LocationInformationRepository()
        {
            collection = _dbContext.LocationDbContext.GetCollection<LocationEntity>("LocationInformationAPI");
        }
        public async Task CreateLocation(LocationEntity location)
        {
            await collection.InsertOneAsync(location);
        }

        public async Task DeleteLocationAsync(string locationId)
        {
            var locationToDelete = Builders<LocationEntity>.Filter.Eq(i => i.Id, new ObjectId(locationId));
            await collection.DeleteOneAsync(locationToDelete);
        }

        public async Task<IEnumerable<LocationEntity>> GetAllLocationsAsync()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<LocationEntity> GetOneLocationAsync(string locationId)
        {
            return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(locationId) } }).Result.FirstAsync();
        }

        public async Task UpdateLocationAsync(string locationId, LocationEntity location)
        {
            var locationToUpdate = Builders<LocationEntity>.Filter.Eq(i => i.Id, location.Id);
            await collection.ReplaceOneAsync(locationToUpdate, location);
        }
    }
}
