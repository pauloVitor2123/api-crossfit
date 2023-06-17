using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IProfessorRepository : IBaseRepository<Professor>
    {
        Task<List<CreateProfessorBody>> GetAllProfessors();
        Task<int> DeleteReturningIdUser(int id);
    }
}
