using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories;
using SistemaCrossfit.Repositories.Interface;
using System.Data;

namespace SistemaCrossfit.Controllers
{
    [Route("api/telephone")]
    [ApiController]
    public class TelephoneController : ControllerBase
    {
        private readonly IBaseRepository<Telephone> _telephoneRepository;

        public TelephoneController(IBaseRepository<Telephone> telephoneRepository)
        {
            _telephoneRepository = telephoneRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Telephone>>> GetTelephones()
        {
            List<Telephone> telephones = await _telephoneRepository.GetAll();
            return Ok(telephones);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Telephone>> GetTelephoneById(int id)
        {
            Telephone telephone = await _telephoneRepository.GetById(id);
            return Ok(telephone);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Telephone>> CreateTelephone([FromBody] Telephone telephone)
        {
            Telephone t = await _telephoneRepository.Create(telephone);
            return Ok(t);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Telephone>> UpdateTelephone(int id, [FromBody] Telephone telephone)
        {
            Telephone t = await _telephoneRepository.Update(telephone, id);
            return Ok(t);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<bool>> DeleteTelephoneById(int id)
        {
            bool deleted = await _telephoneRepository.Delete(id);
            return Ok(deleted);
        }
    }

}
