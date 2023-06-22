using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;
using System.Reflection;

namespace SistemaCrossfit.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Profile>>> GetProfiles()
        {
            List<Profile> profiles = await _profileRepository.GetAll();
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Profile>> GetProfileById(int id)
        {
            Profile profile = await _profileRepository.GetById(id);
            return Ok(profile);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Profile>> CreateProfile([FromBody] Profile profile)
        {
            profile.NormalizedName = profile.Name.ToUpper();
            Profile p = await _profileRepository.Create(profile);
            return Ok(p);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Profile>> UpdatedProfile(int id, [FromBody] Profile profile)
        {
            profile.NormalizedName = profile.Name.ToUpper();
            Profile p = await _profileRepository.Update(profile, id);
            return Ok(p);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Profile>> DeleteProfileById(int id)
        {
            bool deleted = await _profileRepository.Delete(id);
            return Ok(deleted);
        }
    }
}