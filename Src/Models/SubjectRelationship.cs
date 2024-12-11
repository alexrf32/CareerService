using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CareerService.Src.Models
{
    public class SubjectRelationship
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("SubjectCode")]
        public string SubjectCode { get; set; } = string.Empty;

        [BsonElement("PreSubjectCode")]
        public string PreSubjectCode { get; set; } = string.Empty;
    }
}
