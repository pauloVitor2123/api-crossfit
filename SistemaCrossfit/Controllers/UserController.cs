using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }


        /* [HttpPost]
         [Route("login")]
         [AllowAnonymous]
         public async Task<ActionResult<dynamic>> Authenticate([FromBody] User user)
         {

         }*/
    }
}
