using DomainLayer.Entities;

namespace DomainLayer.Interfaces.Repos
{
    public interface IProfileRepo
    {
        Task<Profile?> GetProfileByEmailAsync(string email);
    }
}
