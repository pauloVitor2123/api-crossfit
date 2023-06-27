using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IClassRespository : IBaseRepository<Class>
    {
        Task<List<ClassDTO>> GetAllClassesWithStudentInfo(int idStudent);
        Task<Class> GetByName(string name);
    }
}