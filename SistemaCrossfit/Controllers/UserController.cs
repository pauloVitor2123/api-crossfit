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

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginBody login)
        {
            var response = await _userRepository.Login(login);
            return response;
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

        public async Task<ActionResult<List<User>>> GetUsers()
        {
            List<User> users = await _userRepository.GetAll();
            return Ok(users);
        }
    }
}