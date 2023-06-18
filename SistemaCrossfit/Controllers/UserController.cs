using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        /*        [HttpPost]
                [Route("validate-token")]
                [Authorize]
                public OkObjectResult ValidateToken(string token)
                {
                    if (token == null)
                    {
                        throw new ArgumentNullException("Invalid token");
                    }
                    return Ok(token);
                }*/

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            List<User> users = await _userRepository.GetAll();
            return Ok(users);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Boolean>> DeleteUserById(int id)
        {
            try
            {
                Boolean deleted = await _userRepository.Delete(id);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("professor/{id}")]
        [Authorize]
        public async Task<ActionResult<CreateProfessorBody>> GetProfesssorByUserId(int id)
        {
            User user = await _userRepository.GetById(id);
            Professor professor = await _userRepository.GetProfessorByIdUser(user.IdUser);
            CreateProfessorBody body = new CreateProfessorBody(user, professor.IdProfessor);

            return Ok(body);
        }

        [HttpGet("admin/{id}")]
        [Authorize]
        public async Task<ActionResult<CreateAdminBody>> GetAdminByUserId(int id)
        {
            User user = await _userRepository.GetById(id);
            Admin admin = await _userRepository.GetAdminByIdUser(user.IdUser);
            CreateAdminBody body = new CreateAdminBody(user, admin.IdAdmin);

            return Ok(body);
        }

        [HttpGet("student/{id}")]
        [Authorize]
        public async Task<ActionResult<CreateStudentBody>> GetStudentByUserId(int id)
        {
            User user = await _userRepository.GetById(id);
            Student student = await _userRepository.GetStudentByIdUser(user.IdUser);
            CreateStudentBody body = new CreateStudentBody(user, student);

            return Ok(body);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginBody login)
        {
            var response = await _userRepository.Login(login);
            return response;
        }
    }
}