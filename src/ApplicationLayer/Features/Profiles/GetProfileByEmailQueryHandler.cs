using DomainLayer.Entities;
using DomainLayer.Interfaces.Repos;
using MediatR;

namespace ApplicationLayer.Features.Profiles
{
    public class GetProfileByEmailQueryHandler : IRequestHandler<GetProfileByEmailQuery, Profile?>
    {
        private readonly IProfileRepo _profilRepo;

        public GetProfileByEmailQueryHandler(IProfileRepo? profileRepo)
        {
            _profilRepo = profileRepo ?? throw new ArgumentException(nameof(_profilRepo));
        }
        public async Task<Profile?> Handle(GetProfileByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _profilRepo.GetProfileByEmailAsync(request.Email);
        }
    }
}
