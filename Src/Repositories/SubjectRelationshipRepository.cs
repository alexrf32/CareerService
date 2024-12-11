using CareerService.Src.Models;
using MongoDB.Driver;

namespace CareerService.Src.Repositories
{
    public class SubjectRelationshipRepository
    {
        private readonly IMongoCollection<SubjectRelationship> _subjectRelationships;

        public SubjectRelationshipRepository(IMongoDatabase database)
        {
            _subjectRelationships = database.GetCollection<SubjectRelationship>("SubjectRelationships");
        }

        public async Task<List<SubjectRelationship>> GetAllSubjectRelationshipsAsync()
        {
            return await _subjectRelationships.Find(_ => true).ToListAsync();
        }
    }
}

