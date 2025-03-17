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

        [HttpGet("{email}")]
        public ActionResult<IEnumerable<Profil>> GetProfilByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email cannot be empty!");
            }
            var profil = _context.Profiles.FirstOrDefault(p => p.Email==email);
            if (profil is null)
            {
                return NotFound("Profil not found!");
            }
            return Ok(profil);
        }
    }
}
