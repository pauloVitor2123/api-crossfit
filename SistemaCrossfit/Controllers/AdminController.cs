using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProfileRepository _profileRepository;


        public AdminController(IAdminRepository adminRepository, IUserRepository userRepository, IProfileRepository profileRepository)
        {
            this._adminRepository = adminRepository;
            this._userRepository = userRepository;
            this._profileRepository = profileRepository;

        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<CreateAdminBody>>> GetAdmins()
        {
            List<CreateAdminBody> admins = await _adminRepository.GetAllAdmins();
            return Ok(admins);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CreateAdminBody>> GetAdminById(int id)
        {
            Admin admin = await _adminRepository.GetById(id);
            User user = await _userRepository.GetById(admin.IdUser);
            CreateAdminBody body = new CreateAdminBody(user, admin.IdAdmin);

            return Ok(body);
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> CreateAdmin([FromBody] CreateAdminBody adminBody)
        {
            User user = new User();
            user.Email = adminBody.Email;
            user.Password = adminBody.Password;
            user.Name = adminBody.Name;
            user.SocialName = adminBody.SocialName;

            Profile profile = await _profileRepository.GetByNormalizedName("ADMIN");
            user.IdProfile = profile.IdProfile;
            User userCreated = await _userRepository.Create(user);

            Admin admin = new Admin();
            admin.IdUser = userCreated.IdUser;
            await _adminRepository.Create(admin);

            adminBody.IdAdmin = admin.IdAdmin;
            adminBody.CreatedAt = admin.CreatedAt;
            adminBody.UpdatedAt = admin.UpdatedAt;
            adminBody.DeletedAt = admin.DeletedAt;

            return Ok(adminBody);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Admin>> UpdatedAdmin(int id, [FromBody] CreateAdminBody adminBody)
        {
            User user = new User();
            user.Email = adminBody.Email;
            user.Password = adminBody.Password;
            user.Name = adminBody.Name;
            user.SocialName = adminBody.SocialName;

            await _userRepository.Update(user, id);

            return Ok(adminBody);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Admin>> DeleteStudentById(int id)
        {
            int idUser = await _adminRepository.DeleteReturningIdUser(id);
            Boolean deleted = await _userRepository.Delete(idUser);
            return Ok(deleted);
        }
    }
}
