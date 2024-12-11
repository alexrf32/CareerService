using CareerService.Src.Models;
using MongoDB.Driver;

namespace CareerService.Src.Repositories
{
    public class SubjectRelationshipRepository
    {
        private readonly IMongoCollection<SubjectRelationship> _relationshipsCollection;

        public SubjectRelationshipRepository(IMongoDatabase database)
        {
            _relationshipsCollection = database.GetCollection<SubjectRelationship>("SubjectRelationships");
        }

        public async Task<List<SubjectRelationship>> GetAllRelationshipsAsync()
        {
            return await _relationshipsCollection.Find(r => true).ToListAsync();
        }
    }
}
