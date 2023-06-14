using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDBContext _dbContext;
        public StatusRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<Status>> GetAll()
        {
            return await _dbContext.Status.ToListAsync();
        }

        public async Task<Status> GetById(int id)
        {
            Status? status = await _dbContext.Status.FirstOrDefaultAsync(status => status.IdStatus == id);
            if (status == null)
            {
                throw new Exception("Status not found!");
            }

            return status;
        }

        public async Task<Status> Create(Status status)
        {
            await _dbContext.Status.AddAsync(status);
            await _dbContext.SaveChangesAsync();
            return status;
        }

        public async Task<Status> Update(Status status, int id)
        {
            Status? statusUpdated = await _dbContext.Status.FirstOrDefaultAsync(s => s.IdStatus == id);
            if (statusUpdated == null)
            {
                throw new Exception("Status not found!");
            }

            statusUpdated.NormalizedName = status.NormalizedName;
            statusUpdated.Name = status.Name;
            statusUpdated.Active = status.Active;

            await _dbContext.SaveChangesAsync();

            return statusUpdated;
        }

        public async Task<Boolean> Delete(int id)
        {
            Status? status = await _dbContext.Status.FirstOrDefaultAsync(status => status.IdStatus == id);
            if (status == null)
            {
                throw new Exception("Status not found!");
            }

            _dbContext.Status.Remove(status);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Status> GetByNormalizedName(string normalizedName)
        {
            Status? status = await _dbContext.Status.FirstOrDefaultAsync(status => status.NormalizedName == normalizedName);
            if (status == null)
            {
                throw new Exception("Status not found!");
            }

            return status;
        }
    }
}
