using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
	public interface IPaymentTypeRepository : IBaseRepository<PaymentType>
	{
		Task<PaymentType> GetByName(string name);
	}
}
