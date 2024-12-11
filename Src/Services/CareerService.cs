using CareerService.Protos;
using CareerService.Src.Repositories;
using Grpc.Core;
using Google.Protobuf.WellKnownTypes;

namespace CareerService.Src.Services
{
    public class CareerService : Protos.CareerService.CareerServiceBase
    {
        private readonly CareerRepository _careerRepository;

        public CareerService(CareerRepository careerRepository)
        {
            _careerRepository = careerRepository;
        }

        public override async Task<CareerList> GetAllCareers(Empty request, ServerCallContext context)
        {
            var careers = await _careerRepository.GetAllCareersAsync();

            var response = new CareerList();
            response.Careers.AddRange(careers.Select(c => new Career
            {
                Id = c.Id,
                Name = c.Name,
            }));

            return response;
        }

        public class Protos
        {
            public class SubjectService
            {
                public class SubjectServiceBase
                {
                }
            }

            public class SubjectRelationshipService
            {
                public class SubjectRelationshipServiceBase
                {
                }
            }
        }
    }
}
