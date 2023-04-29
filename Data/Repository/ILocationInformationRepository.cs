using appPrevencionRiesgos.Data.Entities;

namespace appPrevencionRiesgos.Data.Repository
{
    public interface ILocationInformationRepository
    {
        Task<IEnumerable<LocationEntity>> GetAllLocationsAsync();
        Task<LocationEntity> GetOneLocationAsync(string locationId);
        Task CreateLocation(LocationEntity location);
        Task UpdateLocationAsync(string locationId, LocationEntity location);
        Task DeleteLocationAsync(string locationId);
    }
}
