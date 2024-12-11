using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CareerService.Src.Models
{
    public class SubjectRelationship
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("PreSubjectCode")]
        public string PreSubjectCode { get; set; }

        [BsonElement("SubjectCode")]
        public string SubjectCode { get; set; }
    }
}
