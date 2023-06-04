using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<Boolean> Block(int id, string? description);
        Task<Boolean> Unblock(int id);
    }
}
