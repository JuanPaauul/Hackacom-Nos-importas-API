using appPrevencionRiesgos.Model;

namespace appPrevencionRiesgos.Services
{
    public interface ILocationInformationService
    {
        Task<IEnumerable<LocationModel>> GetAllLocationsAsync();
        Task<LocationModel> GetOneLocationAsync(string locationId);
        Task<LocationModel> CreateLocation(LocationModel location);
        Task<LocationModel> UpdateLocationAsync(string locationId, LocationModel location);
        Task DeleteLocationAsync(string locationId);
    }
}
