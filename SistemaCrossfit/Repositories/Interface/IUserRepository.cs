using SistemaCrossfit.DTO.User;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<dynamic> Login(LoginInput login);
        Task<User> Create(User user, string normalizedNameProfile);
        Task<User> GetById(int id);
        Task<Boolean> Delete(int id);
    }
}
