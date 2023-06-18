using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IAdminClassRepository
    {
        Task<AdminClass> GetByIdAdminAndClass(int idAdmin, int idClass);
        Task<List<AdminClass>> GetAllAsync();
    }
}