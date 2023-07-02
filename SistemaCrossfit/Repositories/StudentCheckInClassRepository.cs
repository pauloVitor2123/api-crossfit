using SistemaCrossfit.Data;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories
{
    public class StudentCheckInClassRepository
    {
        private readonly AppDBContext _dbContext;

        public StudentCheckInClassRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(StudentCheckInClass studentCheckInClass)
        {
            await _dbContext.StudentCheckInClass.AddAsync(studentCheckInClass);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(StudentCheckInClass studentCheckInClass)
        {
            _dbContext.StudentCheckInClass.Remove(studentCheckInClass);
            await _dbContext.SaveChangesAsync();
        }

    }
}