using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Controllers
{
    [Route("api/class")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRespository _classRespository;

        public ClassController(IClassRespository classRespository)
        {
            _classRespository = classRespository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Class>>> GetClasses()
        {
            var classes = await _classRespository.GetAll();
            return Ok(classes);
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public async Task<ActionResult<Class>> GetClassById(string name)
        {
            var c = await _classRespository.GetByName(name);
            return Ok(c);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Class>> GetClassById(int id)
        {
            var c = await _classRespository.GetById(id);
            return Ok(c);
        }

        [HttpPost]
        public async Task<ActionResult<Class>> CreateClass([FromBody] Class classCreate)
        {
            var c = await _classRespository.Create(classCreate);
            return Ok(c);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Class>> UpdateClass(int id, [FromBody] Class classes)
        {
            var classUpdate = await _classRespository.Update(classes, id);
            return Ok(classUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Class>> DeleteClassById(int id)
        {
            var deleted = await _classRespository.Delete(id);
            return Ok(deleted);
        }
    }
}