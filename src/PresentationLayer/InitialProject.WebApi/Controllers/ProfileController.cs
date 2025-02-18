using DomainLayer.Commons;
using DomainLayer.Entities;
using InfrastructureLayer.Persistence.Data;
using Microsoft.AspNetCore.Mvc;

namespace InitialProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Profil>> GetProfiles()
        {
            return Ok(_context.Profiles.ToList());
        }
    }
}
