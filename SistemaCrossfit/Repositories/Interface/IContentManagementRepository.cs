using SistemaCrossfit.DTO;
using SistemaCrossfit.Request;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IContentManagementRepository
    {
        Task<ContentManagementDto> Get();
        Task CreateorUpdate(ContentManagementRequest entityModel);
    }
}
