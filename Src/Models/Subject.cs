using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CareerService.Src.Models
{
    public class Subject
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Code")]
        public string Code { get; set; } = string.Empty;

        [BsonElement("Name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("Department")]
        public string Department { get; set; } = string.Empty;

        [BsonElement("Credits")]
        public int Credits { get; set; }

        [BsonElement("Semester")]
        public int Semester { get; set; }
    }
}
