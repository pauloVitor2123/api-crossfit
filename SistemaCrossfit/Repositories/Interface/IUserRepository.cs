using SistemaCrossfit.DTO.User;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<dynamic> Login(LoginInput login);
    }
}
