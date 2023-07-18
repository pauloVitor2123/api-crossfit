using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IClassRespository : IBaseRepository<Class>
    {
        new Task<ClassDTO> GetById(int id);
        new Task<List<ClassDTO>> GetAll();
        Task<List<ClassDTO>> GetAllClassesWithStudentInfo(int idStudent);
        Task<Class> GetByName(string name);
    }
}