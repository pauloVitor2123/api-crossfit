using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IStatusRepository : IBaseRepository<Status>
    {
        Task<Status> GetByNormalizedName(string normalizedName);
    }
}
