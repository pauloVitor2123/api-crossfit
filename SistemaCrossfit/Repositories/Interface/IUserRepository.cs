using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> login(User user);
    }
}
