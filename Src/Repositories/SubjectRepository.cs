using CareerService.Src.Models;
using MongoDB.Driver;

namespace CareerService.Src.Repositories
{
    public class SubjectRepository
    {
        private readonly IMongoCollection<Subject> _subjectsCollection;

        public SubjectRepository(IMongoDatabase database)
        {
            _subjectsCollection = database.GetCollection<Subject>("Subjects");
        }

        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            return await _subjectsCollection.Find(s => true).ToListAsync();
        }
    }
}
