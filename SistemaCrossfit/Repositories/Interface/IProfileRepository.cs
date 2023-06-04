using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IProfileRepository : IBaseRepository<Profile>
    {
        Task<Profile> GetByNormalizedName(string normalizedName);
    }
}
