using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Controllers
{
    [Route("api/class")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRespository _classRespository;
        private readonly AppDBContext _dbContext;

        public ClassController(IClassRespository classRespository, AppDBContext dbContext)
        {
            _classRespository = classRespository;
            _dbContext = dbContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Class>>> GetClasses(int? idStudent)
        {
            if (!idStudent.HasValue)
            {
                var classes = await _classRespository.GetAll();
                return Ok(classes);
            }
            var classesWithStudentInfo = await _classRespository.GetAllClassesWithStudentInfo(idStudent.Value);
            return Ok(classesWithStudentInfo);
        }
        [HttpGet("student-home/{idStudent}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Class>>> GetClassesWithStudentInfo(int idStudent)
        {
            var classesWithStudentInfo = await _classRespository.GetAllClassesWithStudentInfo(idStudent);
            return Ok(classesWithStudentInfo);
        }

        [HttpGet("search/{name}")]
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

        [HttpPost("{idAdmin}")]
        [Authorize]
        public async Task<ActionResult<Class>> CreateClass([FromBody] Class classCreate, int idAdmin)
        {
            var c = await _classRespository.Create(classCreate);
            var idClass = c.IdClass;

            var adminClassRepository = new AdminClassRepository(_dbContext);

            var adminClass = new AdminClass
            {
                IdAdmin = idAdmin,
                IdClass = idClass
            };

            await adminClassRepository.AddAsync(adminClass);

            return Ok(c);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Class>> UpdateClass(int id, [FromBody] Class classes)
        {
            var classUpdate = await _classRespository.Update(classes, id);
            return Ok(classUpdate);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Class>> DeleteClassById(int id)
        {
            var deleted = await _classRespository.Delete(id);
            return Ok(deleted);
        }
    }
}