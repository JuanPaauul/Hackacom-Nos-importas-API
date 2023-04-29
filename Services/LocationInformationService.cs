using appPrevencionRiesgos.Data.Entities;
using appPrevencionRiesgos.Data.Repository;
using appPrevencionRiesgos.Exceptions;
using appPrevencionRiesgos.Model;
using AutoMapper;
using Microsoft.VisualBasic;
using MongoDB.Bson;

namespace appPrevencionRiesgos.Services
{
    public class LocationInformationService : ILocationInformationService
    {
        private ILocationInformationRepository _locationRepository;
        private IMapper _mapper;
        public LocationInformationService(ILocationInformationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public async Task<LocationModel> CreateLocation(LocationModel location)
        {
            var locationEntity = _mapper.Map<LocationEntity>(location);
            await _locationRepository.CreateLocation(locationEntity);
            if (true)
            {
                return _mapper.Map<LocationModel>(locationEntity);
            }
            throw new Exception("Database Error.");
        }

        public async Task DeleteLocationAsync(string locationId)
        {
            var result = await GetOneLocationAsync(locationId);
            await _locationRepository.DeleteLocationAsync(locationId);
            if (result == null)
            {
                throw new Exception("Database Error.");
            }
        }

        public async Task<IEnumerable<LocationModel>> GetAllLocationsAsync()
        {
            var locationEntityList = await _locationRepository.GetAllLocationsAsync();
            return _mapper.Map<IEnumerable<LocationModel>>(locationEntityList);
        }

        public async Task<LocationModel> GetOneLocationAsync(string locationId)
        {
            var location = await _locationRepository.GetOneLocationAsync(locationId);

            if (location == null)
                throw new NotFoundElementException($"Information with id:{locationId} does not exists.");

            return _mapper.Map<LocationModel>(location);
        }

        public async Task<LocationModel> UpdateLocationAsync(string locationId, LocationModel location)
        {
            var result = await GetOneLocationAsync(locationId);
            var locationEntity = _mapper.Map<LocationEntity>(location);
            locationEntity.Id = new ObjectId(locationId);

            await _locationRepository.UpdateLocationAsync(locationId, locationEntity);

            if (result != null)
            {
                return _mapper.Map<LocationModel>(locationEntity);
            }

            throw new Exception("Database Error.");
        }
    }
}
