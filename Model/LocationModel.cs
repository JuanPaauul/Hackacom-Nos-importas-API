using Microsoft.ProjectServer.Client;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace appPrevencionRiesgos.Model
{
    public class LocationModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string? Location { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? RiskZone { get; set; } = "";
    }
}
