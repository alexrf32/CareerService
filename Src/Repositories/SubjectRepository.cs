using CareerService.Src.Models;
using MongoDB.Driver;

namespace CareerService.Src.Repositories
{
    public class SubjectRepository
    {
        private readonly IMongoCollection<Subject> _subjects;

        public SubjectRepository(IMongoDatabase database)
        {
            _subjects = database.GetCollection<Subject>("Subject");
        }

        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            return await _subjects.Find(_ => true).ToListAsync();
        }
    }
}

