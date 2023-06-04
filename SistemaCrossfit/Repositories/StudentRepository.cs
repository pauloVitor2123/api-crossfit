using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class StudentRepository : IBaseRepository<Student>
    {
        private readonly AppDBContext _dbContext;
        public StudentRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<Student>> GetAll()
        {
            return await _dbContext.Student.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            Student student = await _dbContext.Student.FirstOrDefaultAsync(student => student.IdStudent == id);
            if (student == null)
            {
                throw new Exception("User not found!");
            }

            return student;
        }

        public async Task<Student> Create(Student student)
        {
            await _dbContext.Student.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student> Update(Student student, int id)
        {
            Student studentUpdated = await _dbContext.Student.FirstOrDefaultAsync(p => p.IdProfile == id);
            if (studentUpdated == null)
            {
                throw new Exception("User not found!");
            }

            studentUpdated.Name = student.Name;
            studentUpdated.Email = student.Email;
            studentUpdated.IdGenre = student.IdGenre;
            studentUpdated.BirthDate = student.BirthDate;
            studentUpdated.SocialName = student.SocialName;

            await _dbContext.SaveChangesAsync();

            return studentUpdated;
        }

        public async Task<Boolean> Delete(int id)
        {
            Student student = await _dbContext.Student.FirstOrDefaultAsync(student => student.IdStudent == id);
            if (student == null)
            {
                throw new Exception("User not found!");
            }

            _dbContext.Student.Remove(student);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
