using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;
using Swashbuckle.AspNetCore.Annotations;

namespace SistemaCrossfit.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IBaseRepository<Profile> _profileRepository;
        public ProfileController(IBaseRepository<Profile> profileRepository)
        {
            this._profileRepository = profileRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Profile>>> GetProfiles()
        {
            List<Profile> profiles = await _profileRepository.GetAll();
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfileById(int id)
        {
            Profile profile = await _profileRepository.GetById(id);
            return Ok(profile);
        }

        [HttpPost]
        public async Task<ActionResult<Profile>> CreateProfile([FromBody] Profile profile)
        {
            Profile p = await _profileRepository.Create(profile);
            return Ok(p);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Profile>> UpdatedProfile(int id, [FromBody] Profile profile)
        {
            Profile p = await _profileRepository.Update(profile, id);
            return Ok(p);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Profile>> DeleteById(int id)
        {
            Boolean deleted = await _profileRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
