using DomainLayer.Entities;
using MediatR;

namespace ApplicationLayer.Features.Profiles
{
    public record GetProfileByEmailQuery(string Email) : IRequest<Profile?>;
}
