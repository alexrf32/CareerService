using System.Threading.Tasks;
using CareerService.Src.Repositories;
using CareerService.Protos;
using Grpc.Core;
using Google.Protobuf.WellKnownTypes;

namespace CareerService.Src.Services
{
    public class SubjectService : Protos.SubjectService.SubjectServiceBase
    {
        private readonly SubjectRepository _subjectRepository;

        public SubjectService(SubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public override async Task<SubjectList> GetAllSubjects(Empty request, ServerCallContext context)
        {
            var subjects = await _subjectRepository.GetAllSubjectsAsync();

            // Log temporal
            Console.WriteLine($"Subjects retrieved: {subjects.Count}");

            var response = new SubjectList();
            response.Subjects.AddRange(subjects.Select(s => new Subject
            {
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Department = s.Department,
                Credits = s.Credits,
                Semester = s.Semester
            }));

            return response;
        }
    }
}

