using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IBaseRepository<Student> _studentRepository;
        public StudentController(IBaseRepository<Student> studentRepository)
        {
            this._studentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            List<Student> students = await _studentRepository.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            Student student = await _studentRepository.GetById(id);
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent([FromBody] Student student)
        {
            Student p = await _studentRepository.Create(student);
            return Ok(p);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdatedStudent(int id, [FromBody] Student student)
        {
            Student s = await _studentRepository.Update(student, id);
            return Ok(s);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteById(int id)
        {
            Boolean deleted = await _studentRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
