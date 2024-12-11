using CareerService.Protos;
using CareerService.Src.Repositories;
using Grpc.Core;
using Google.Protobuf.WellKnownTypes;

namespace CareerService.Src.Services
{
    public class SubjectRelationshipServiceImpl : SubjectRelationshipService.SubjectRelationshipServiceBase
    {
        private readonly SubjectRelationshipRepository _repository;

        public SubjectRelationshipServiceImpl(SubjectRelationshipRepository repository)
        {
            _repository = repository;
        }

        public override async Task<SubjectRelationshipList> GetAllSubjectRelationships(Empty request, ServerCallContext context)
        {
            var subjectRelationships = await _repository.GetAllSubjectRelationshipsAsync();

            var response = new SubjectRelationshipList();
            response.SubjectRelationships.AddRange(subjectRelationships.Select(sr => new SubjectRelationship
            {
                Id = sr.Id,
                SubjectCode = sr.SubjectCode,
                PreSubjectCode = sr.PreSubjectCode
            }));

            return response;
        }
    }
}
