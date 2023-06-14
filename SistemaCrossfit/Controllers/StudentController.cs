using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly IUserRepository _userRepository;

        public StudentController(IStudentRepository studentRepository, IProfileRepository profileRepository, IUserRepository userRepository)
        {
            this._studentRepository = studentRepository;
            _profileRepository = profileRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<CreateStudentBody>>> GetStudents()
        {
            var students = await _studentRepository.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _studentRepository.GetById(id);
            var user = await _userRepository.GetById(student.IdUser);
            var body = new CreateStudentBody(user, student);

            return Ok(body);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Student>> CreateStudent([FromBody] CreateStudentBody studentBody)
        {
            var user = new User();
            user.Email = studentBody.Email;
            user.Password = studentBody.Password;
            user.Name = studentBody.Name;
            user.SocialName = studentBody.SocialName;

            var profile = await _profileRepository.GetByNormalizedName("STUDENT");
            user.IdProfile = profile.IdProfile;
            var userCreated = await _userRepository.Create(user);

            var student = new Student();
            student.IdUser = userCreated.IdUser;
            await _studentRepository.Create(student);

            studentBody.IdStudent = student.IdStudent;
            studentBody.IdAddress = student.IdAddress;
            studentBody.IdGenre = student.IdGenre;
            studentBody.BirthDate = student.BirthDate;
            studentBody.IsBlocked = student.IsBlocked;
            studentBody.BlockDescription = student.BlockDescription;
            studentBody.CreatedAt = student.CreatedAt;
            studentBody.UpdatedAt = student.UpdatedAt;
            studentBody.DeletedAt = student.DeletedAt;

            return Ok(studentBody);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<CreateStudentBody>> UpdatedStudent(int id, [FromBody] CreateStudentBody studentBody)
        {
            var user = new User();
            user.Email = studentBody.Email;
            user.Password = studentBody.Password;
            user.Name = studentBody.Name;
            user.SocialName = studentBody.SocialName;

            var student = await _studentRepository.GetById(id);
            await _userRepository.Update(user, student.IdUser);

            await _studentRepository.Update(student, id);

            return Ok(studentBody);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Student>> DeleteStudentById(int id)
        {
            int idUser = await _studentRepository.DeleteReturningIdUser(id);
            bool deleted = await _userRepository.Delete(idUser);
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
            bool blocked = await _studentRepository.Block(id, blockRequest.BlockDescription);
            return Ok(blocked);
        }

        [HttpPatch("unblock/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Student>> UnblockStudentById(int id)
        {
            bool unblocked = await _studentRepository.Unblock(id);
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