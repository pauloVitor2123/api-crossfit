using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Data;
using SistemaCrossfit.DTO;
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
        private readonly IProfileRepository _profileRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IProfileRepository profileRepository, IUserRepository userRepository, AppDBContext dbContext, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _profileRepository = profileRepository;
            _userRepository = userRepository;
            _dbContext = dbContext;
            _mapper = mapper;
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

        [HttpPost("student/checkin/{idStudent}/{idClass}")]
        [AllowAnonymous]
        public async Task<ActionResult<Student>> CreateStudent([FromBody] CreateStudentBody studentBody, int idStudent, int idClass)
        {
            var user = await CreateUser(studentBody);
            var userCreated = await _userRepository.Create(user);

            var student = new Student
            {
                IdUser = userCreated.IdUser
            };
            await _studentRepository.Create(student);

            var studentCheckInClassRepository = new StudentCheckInClassRepository(_dbContext);

            var studentClass = new StudentCheckInClass()
            {
                IdStudent = idStudent,
                IdClass = idClass
            };

            await studentCheckInClassRepository.AddAsync(studentClass);

            var mappedStudentBody = _mapper.Map<CreateStudentBody>(student);
            MapStudentData(studentBody, student);

            return Ok(mappedStudentBody);
        }

        private static void MapStudentData(CreateStudentBody studentBody, Student student)
        {
            studentBody.IdStudent = student.IdStudent;
            studentBody.IdAddress = student.IdAddress;
            studentBody.IdGenre = student.IdGenre;
            studentBody.BirthDate = student.BirthDate;
            studentBody.IsBlocked = student.IsBlocked;
            studentBody.BlockDescription = student.BlockDescription;
        }

        private async Task<User> CreateUser(CreateStudentBody studentBody)
        {
            var user = new User
            {
                Email = studentBody.Email,
                Password = studentBody.Password,
                Name = studentBody.Name,
                SocialName = studentBody.SocialName
            };

            var profile = await _profileRepository.GetByNormalizedName("STUDENT");
            user.IdProfile = profile.IdProfile;
            return await _userRepository.Create(user);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<CreateStudentBody>> UpdatedStudent(int id, [FromBody] CreateStudentBody studentBody)
        {
            var student = await _studentRepository.GetById(id);
            User user = await _userRepository.GetById(student.IdUser);
            user.IdUser = student.IdUser;
            user.Email = studentBody.Email;
            user.Password = studentBody.Password;
            user.Name = studentBody.Name;
            user.SocialName = studentBody.SocialName;
            student.BirthDate = studentBody.BirthDate;
            if (studentBody.IdGenre != 0)
            {
                student.IdGenre = studentBody.IdGenre;
            }

            await _userRepository.Update(user);

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