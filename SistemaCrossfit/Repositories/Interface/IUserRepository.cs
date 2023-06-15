using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<dynamic> Login(LoginBody login);
        Task<List<User>> GetAll();
        Task<User> Create(User user);
        Task<User> Update(User user, int id);
        Task<User> GetById(int id);
        Task<Boolean> Delete(int id);
    }
}
