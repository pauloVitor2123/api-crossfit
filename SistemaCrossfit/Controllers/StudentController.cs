using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.DTO.Student;
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
        public StudentController(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            List<Student> students = await _studentRepository.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            Student student = await _studentRepository.GetById(id);
            return Ok(student);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Student>> CreateStudent([FromBody] CreateStudent student)
        {
            Student s = await _studentRepository.Create(student);
            return Ok(s);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Student>> UpdatedStudent(int id, [FromBody] CreateStudent student)
        {
            Student s = await _studentRepository.Update(student, id);
            return Ok(s);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Student>> DeleteStudentById(int id)
        {
            Boolean deleted = await _studentRepository.Delete(id);
            return Ok(deleted);
        }

        public class BlockRequest
        {
            public string BlockDescription { get; set; }
        }


        [HttpPatch("block/{id}")]
        [Authorize]
        public async Task<ActionResult<Student>> BlockStudentById(int id, [FromBody] BlockRequest blockRequest)
        {
            Boolean blocked = await _studentRepository.Block(id, blockRequest.BlockDescription);
            return Ok(blocked);
        }

        [HttpPatch("unblock/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Student>> UnblockStudentById(int id)
        {
            Boolean unblocked = await _studentRepository.Unblock(id);
            return Ok(unblocked);
        }

        [HttpPatch("{idStudent}/address/{idAddress}")]
        [Authorize]
        public async Task<ActionResult<Student>> UnblockStudentById(int idStudent, int idAddress)
        {
            Student student = await _studentRepository.ConnectAddressWithStudent(idStudent, idAddress);
            return Ok(student);
        }
    }
}
