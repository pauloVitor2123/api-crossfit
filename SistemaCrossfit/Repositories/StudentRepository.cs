using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDBContext _dbContext;
        public StudentRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<Student>> GetAll()
        {
            ProfileRepository profileRepository = new ProfileRepository(_dbContext);
            Profile profile = await profileRepository.GetByNormalizedName("STUDENT");

            return await _dbContext.Student.Where(student => student.IdProfile == profile.IdProfile).ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            Student student = await _dbContext.Student.FirstOrDefaultAsync(student => student.IdStudent == id);
            if (student == null)
            {
                throw new Exception("Student not found!");
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
            Student studentUpdated = await _dbContext.Student.FirstOrDefaultAsync(s => s.IdStudent == id);
            if (studentUpdated == null)
            {
                throw new Exception("Student not found!");
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
                throw new Exception("Student not found!");
            }

            _dbContext.Student.Remove(student);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Block(int id, string? description = "")
        {
            Student studentUpdated = await _dbContext.Student.FirstOrDefaultAsync(s => s.IdStudent == id);
            if (studentUpdated == null)
            {
                throw new Exception("Student not found!");
            }

            studentUpdated.IsBlocked = true;
            studentUpdated.BlockDescription = description;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Unblock(int id)
        {
            Student studentUpdated = await _dbContext.Student.FirstOrDefaultAsync(s => s.IdStudent == id);
            if (studentUpdated == null)
            {
                throw new Exception("Student not found!");
            }

            studentUpdated.IsBlocked = false;
            studentUpdated.BlockDescription = null;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
