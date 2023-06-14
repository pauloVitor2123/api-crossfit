using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class TelephoneRepository : IBaseRepository<Telephone>
    {
        private readonly AppDBContext _dbContext;
        public TelephoneRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<Telephone>> GetAll()
        {
            return await _dbContext.Telephone.ToListAsync();
        }

        public async Task<Telephone> GetById(int id)
        {
            Telephone? telephone = await _dbContext.Telephone.FirstOrDefaultAsync(t => t.IdTelephone == id);
            if (telephone == null)
            {
                throw new Exception("Telephone not found!");
            }

            return telephone;
        }

        public async Task<Telephone> Create(Telephone telephone)
        {
            await _dbContext.Telephone.AddAsync(telephone);
            await _dbContext.SaveChangesAsync();
            return telephone;
        }

        public async Task<Telephone> Update(Telephone telephone, int id)
        {
            Telephone? telephoneUpdated = await _dbContext.Telephone.FirstOrDefaultAsync(t => t.IdTelephone == id);
            if (telephoneUpdated == null)
            {
                throw new Exception("Telephone not found!");
            }

            telephoneUpdated.IdStudent = telephone.IdStudent;
            telephoneUpdated.Number = telephone.Number;

            await _dbContext.SaveChangesAsync();

            return telephoneUpdated;
        }

        public async Task<bool> Delete(int id)
        {
            Telephone? telephone = await _dbContext.Telephone.FirstOrDefaultAsync(t => t.IdTelephone == id);
            if (telephone == null)
            {
                throw new Exception("Telephone not found!");
            }

            _dbContext.Telephone.Remove(telephone);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
