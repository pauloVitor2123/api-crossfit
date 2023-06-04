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
        private readonly IStudentRepository _studentRepository;
        public StudentController(StudentRepository studentRepository)
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

        public class BlockRequest
        {
            public string BlockDescription { get; set; }
        }


        [HttpPatch("block/{id}")]
        public async Task<ActionResult<Student>> BlockById(int id, [FromBody] BlockRequest blockRequest)
        {
            Boolean blocked = await _studentRepository.Block(id, blockRequest.BlockDescription);
            return Ok(blocked);
        }

        [HttpPatch("unblock/{id}")]
        public async Task<ActionResult<Student>> UnblockById(int id)
        {
            Boolean unblocked = await _studentRepository.Unblock(id);
            return Ok(unblocked);
        }
    }
}
