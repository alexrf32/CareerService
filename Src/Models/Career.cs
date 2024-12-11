using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CareerService.Src.Models
{
    public class Career
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;
    }
}
