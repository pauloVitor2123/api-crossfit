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
            _dbContext.StudentCheckInClass.Add(studentCheckInClass);
            await _dbContext.SaveChangesAsync();
        }
    }
}