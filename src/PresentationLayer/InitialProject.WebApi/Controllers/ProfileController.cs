using ApplicationLayer.Dtos;
using ApplicationLayer.Features.Profiles;
using DomainLayer.Commons;
using DomainLayer.Entities;
using InfrastructureLayer.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InitialProject.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfilesController(IMediator? mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfilByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email cannot be empty!");
            }
            var profil = await _mediator.Send(new GetProfileByEmailQuery(email));
            if (profil is null)
            {
                return NotFound("Profil not found!");
            }

            var profilDto = new ProfileDto
            {
                Id = profil.Id,
                Name = profil.Name,
                Email=profil.Email
            };
            return Ok(profil);
        }
    }
}
