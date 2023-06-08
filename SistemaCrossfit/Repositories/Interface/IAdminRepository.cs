using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        Task<List<CreateAdminBody>> GetAllAdmins();
        Task<int> DeleteReturningIdUser(int id);
    }
}
