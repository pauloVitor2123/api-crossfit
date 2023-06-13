using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
	public class PaymentTypeRepository : IPaymentTypeRepository
	{
		private readonly AppDBContext _dbContext;
		public PaymentTypeRepository(AppDBContext appDBContext)
		{
			_dbContext = appDBContext;
		}

		public async Task<List<PaymentType>> GetAll()
		{
			return await _dbContext.PaymentType.ToListAsync();
		}

		public async Task<PaymentType> GetById(int id)
		{
			PaymentType paymentType = await _dbContext.PaymentType.FirstOrDefaultAsync(p => p.IdPaymentType == id);
			if (paymentType == null)
			{
				throw new Exception("PaymentType not found!");
			}

			return paymentType;
		}

		public async Task<PaymentType> Create(PaymentType paymentType)
		{
			await _dbContext.PaymentType.AddAsync(paymentType);
			await _dbContext.SaveChangesAsync();
			return paymentType;
		}

		public async Task<PaymentType> Update(PaymentType paymentType, int id)
		{
			PaymentType paymentTypeUpdated = await _dbContext.PaymentType.FirstOrDefaultAsync(p => p.IdPaymentType == id);
			if (paymentTypeUpdated == null)
			{
				throw new Exception("PaymentType not found!");
			}

			paymentTypeUpdated.Name = paymentType.Name;

			await _dbContext.SaveChangesAsync();

			return paymentTypeUpdated;
		}

		public async Task<bool> Delete(int id)
		{
			PaymentType paymentType = await _dbContext.PaymentType.FirstOrDefaultAsync(p => p.IdPaymentType == id);
			if (paymentType == null)
			{
				throw new Exception("PaymentType not found!");
			}

			_dbContext.PaymentType.Remove(paymentType);
			await _dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<PaymentType> GetByName(string name)
		{
			PaymentType paymentType = await _dbContext.PaymentType.FirstOrDefaultAsync(p => p.Name == name);
			if (paymentType == null)
			{
				throw new Exception("PaymentType not found!");
			}

			return paymentType;
		}
	}
}
