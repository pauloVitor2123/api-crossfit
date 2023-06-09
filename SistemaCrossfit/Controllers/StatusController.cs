using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaCrossfit.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Status>>> GetStatuses()
        {
            List<Status> statuses = await _statusRepository.GetAll();
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Status>> GetStatusById(int id)
        {
            Status status = await _statusRepository.GetById(id);
            return Ok(status);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Status>> CreateStatus([FromBody] Status status)
        {
            Status s = await _statusRepository.Create(status);
            return Ok(s);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Status>> UpdateStatus(int id, [FromBody] Status status)
        {
            Status s = await _statusRepository.Update(status, id);
            return Ok(s);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Boolean>> DeleteStatusById(int id)
        {
            Boolean deleted = await _statusRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
