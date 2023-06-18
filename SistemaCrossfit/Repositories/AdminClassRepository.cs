using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class AdminClassRepository : IAdminClassRepository
    {
        private readonly AppDBContext _dbContext;

        public AdminClassRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(AdminClass adminClass)
        {
            _dbContext.AdminClass.Add(adminClass);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<AdminClass> GetByIdAdminAndClass(int idAdmin, int idClass)
        {
            var adminClass = await _dbContext.AdminClass
                .Where(ac => ac.IdAdmin == idAdmin && ac.IdClass == idClass)
                .FirstOrDefaultAsync();

            return adminClass;
        }

        public async Task<List<AdminClass>> GetAllAsync()
        {
            return await _dbContext.AdminClass.ToListAsync();
        }
    }
}
