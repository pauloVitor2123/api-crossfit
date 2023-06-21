using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;
using System.Data;

namespace SistemaCrossfit.Controllers
{
    [Route("api/gender")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IBaseRepository<Gender> _genderRepository;
        public GenderController(IBaseRepository<Gender> GenderRepository)
        {
            this._genderRepository = GenderRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Gender>>> GetGenders()
        {
            List<Gender> genders = await _genderRepository.GetAll();
            return Ok(genders);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Gender>> GetGenderById(int id)
        {
            Gender gender = await _genderRepository.GetById(id);
            return Ok(gender);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Gender>> CreateGender([FromBody] Gender gender)
        {
            gender.NormalizedName = gender.Name.ToUpper();
            Gender g = await _genderRepository.Create(gender);
            return Ok(g);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Gender>> UpdatedGender(int id, [FromBody] Gender gender)
        {
            gender.NormalizedName = gender.Name.ToUpper();
            Gender g = await _genderRepository.Update(gender, id);
            return Ok(g);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Gender>> DeleteGenderById(int id)
        {
            Boolean deleted = await _genderRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
