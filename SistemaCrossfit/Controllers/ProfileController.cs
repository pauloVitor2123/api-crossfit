using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileController(IProfileRepository profileRepository)
        {
            this._profileRepository = profileRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProfileModel>>> GetProfiles()
        {
            List<ProfileModel> profiles = await _profileRepository.GetAll();
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileModel>> GetProfileById(int id)
        {
            ProfileModel profile = await _profileRepository.GetById(id);
            return Ok(profile);
        }

        [HttpPost]
        public async Task<ActionResult<ProfileModel>> GetProfileById([FromBody] ProfileModel profile)
        {
            ProfileModel p = await _profileRepository.Create(profile);
            return Ok(p);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProfileModel>> UpdatedProfile(int id, [FromBody] ProfileModel profile)
        {
            ProfileModel p = await _profileRepository.Update(profile, id);
            return Ok(p);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfileModel>> DeleteById(int id)
        {
            Boolean deleted = await _profileRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
