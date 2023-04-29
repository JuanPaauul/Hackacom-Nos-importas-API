using appPrevencionRiesgos.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using appPrevencionRiesgos.Model.Security;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace appPrevencionRiesgos.Services;

public class MongoDBService: IMongoDBServices
{

    private readonly IMongoCollection<UserInformationModel> _userCollection;
    private UserManager<IdentityUser> userManager;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings )
    {
        

        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _userCollection = database.GetCollection<UserInformationModel>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<UserInformationModel>> GetAsync()
    {
        return await _userCollection.Find(_ => true).ToListAsync();
    }
    public async Task CreateAsync(UserInformationModel user) =>
        await _userCollection.InsertOneAsync(user);
    public async Task AddToPlaylistAsync(string id, string movieId) { }
    public async Task DeleteAsync(string id) { }

}