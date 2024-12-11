using CareerService.Src.Models;
using MongoDB.Driver;

namespace CareerService.Src.Repositories
{
    public class CareerRepository
    {
        private readonly IMongoCollection<Career> _careersCollection;

        public CareerRepository(IMongoDatabase database)
        {
            _careersCollection = database.GetCollection<Career>("Careers");
        }

        public async Task<List<Career>> GetAllCareersAsync()
        {
            return await _careersCollection.Find(c => true).ToListAsync();
        }
    }
}
