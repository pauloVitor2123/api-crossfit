using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IBaseRepository<EntityModel>
    {
        Task<List<EntityModel>> GetAll();
        Task<EntityModel> GetById(int id);
        Task<EntityModel> Create(EntityModel entityModel);
        Task<EntityModel> Update(EntityModel entityModel, int id);
        Task<Boolean> Delete(int id);
    }
}
