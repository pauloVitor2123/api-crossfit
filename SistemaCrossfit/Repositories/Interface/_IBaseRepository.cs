using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IBaseRepository<EntityModel>
    {
        Task<List<EntityModel>> GetAll();
        Task<EntityModel> GetById(int id);
        Task<EntityModel> Create(EntityModel profile);
        Task<EntityModel> Update(EntityModel profile, int id);
        Task<Boolean> Delete(int id);
    }
}
