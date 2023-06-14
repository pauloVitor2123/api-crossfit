using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IClassRespository : IBaseRepository<Class>
    {
        Task<List<Class>> GetAll();
        Task<Class> GetByName(string name);
    }
}