using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Controllers
{
    [Route("api/professor")]
    [ApiController]
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;


        public ProfessorController(IProfessorRepository professorRepository, IUserRepository userRepository, IProfileRepository profileRepository)
        {
            this._professorRepository = professorRepository;
            this._userRepository = userRepository;
            this._profileRepository = profileRepository;

        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<CreateProfessorBody>>> GetProfessors()
        {
            List<CreateProfessorBody> professors = await _professorRepository.GetAllProfessors();
            return Ok(professors);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CreateProfessorBody>> GetProfessorById(int id)
        {
            Professor professor = await _professorRepository.GetById(id);
            User user = await _userRepository.GetById(professor.IdUser);
            CreateProfessorBody body = new CreateProfessorBody(user, professor.IdProfessor);

            return Ok(body);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Professor>> CreateProfessor([FromBody] CreateProfessorBody professorBody)
        {
            User user = new User();
            user.Email = professorBody.getEmail();
            user.Password = professorBody.getPassword();
            user.Name = professorBody.Name;
            user.SocialName = professorBody.SocialName;

            Profile profile = await _profileRepository.GetByNormalizedName("PROFESSOR");
            user.IdProfile = profile.IdProfile;
            User userCreated = await _userRepository.Create(user);

            Professor professor = new Professor();
            professor.IdUser = userCreated.IdUser;
            await _professorRepository.Create(professor);

            professorBody.IdProfessor = professor.IdProfessor;
            professorBody.CreatedAt = professor.CreatedAt;
            professorBody.UpdatedAt = professor.UpdatedAt;
            professorBody.DeletedAt = professor.DeletedAt;

            return Ok(professorBody);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Professor>> UpdatedProfessor(int id, [FromBody] CreateProfessorBody professorBody)
        {
            Professor professor = await _professorRepository.GetById(id);
            User user = await _userRepository.GetById(professor.IdUser);
            user.Name = professorBody.Name;
            user.SocialName = professorBody.SocialName;

            await _userRepository.Update(user);

            return Ok(professorBody);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<Professor>> DeleteProfessorById(int id)
        {
            int idUser = await _professorRepository.DeleteReturningIdUser(id);
            Boolean deleted = await _userRepository.Delete(idUser);
            return Ok(deleted);
        }
    }
}
