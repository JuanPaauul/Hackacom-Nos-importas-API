using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace appPrevencionRiesgos.Data.Entities
{
    public class LocationEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string? Location { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? RiskZone { get; set; } = "";
    }
}
