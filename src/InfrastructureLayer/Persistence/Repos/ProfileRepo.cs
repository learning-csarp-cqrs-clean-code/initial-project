using DomainLayer.Entities;
using DomainLayer.Interfaces.Repos;
using InfrastructureLayer.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Persistence.Repos
{
    public class ProfileRepo : IProfileRepo
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepo(ApplicationDbContext? applicationDbContext)
        {
            _context = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public async Task<Profile?> GetProfileByEmailAsync(string email)
        {
            return await _context.Profiles.FirstOrDefaultAsync(p => p.Email == email);
        }
    }
}
