using appPrevencionRiesgos.Model.Security;
using Microsoft.AspNetCore.Identity;

namespace appPrevencionRiesgos.Services
{
    public interface IMongoDBServices
    {
        Task<List<UserInformationModel>> GetAsync();
         Task CreateAsync(UserInformationModel user);
         Task AddToPlaylistAsync(string id, string movieId);
        Task DeleteAsync(string id);
    }
}
