using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.DTO.Student;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;
using System.Net;

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
            return await _dbContext.Student.ToListAsync();
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

        public async Task<Student> Create(CreateStudent httpStudent)
        {
            User user = new User();
            user.Name = httpStudent.Name;
            user.Email = httpStudent.Email;
            user.Password = httpStudent.Password;
            user.SocialName = httpStudent.SocialName;
            user.IdProfile = httpStudent.IdProfile;

            await _dbContext.User.AddAsync(user);

            Student student = new Student();
            student.IdAddress = httpStudent.IdAddress;
            student.IdGenre = httpStudent.IdGenre;
            student.BirthDate = httpStudent.BirthDate;

            await _dbContext.Student.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student> Update(CreateStudent httpStudent, int id)
        {
            Student studentUpdated = await _dbContext.Student.FirstOrDefaultAsync(s => s.IdStudent == id);
            if (studentUpdated == null)
            {
                throw new Exception("Student not found!");
            }

            studentUpdated.User.Name = httpStudent.Name;
            studentUpdated.User.Email = httpStudent.Email;
            studentUpdated.User.Password = httpStudent.Password;
            studentUpdated.User.SocialName = httpStudent.SocialName;
            studentUpdated.User.IdProfile = httpStudent.IdProfile;

            studentUpdated.IdAddress = httpStudent.IdAddress;
            studentUpdated.IdGenre = httpStudent.IdGenre;
            studentUpdated.BirthDate = httpStudent.BirthDate;

            await _dbContext.Student.AddAsync(studentUpdated);
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

        public async Task<Student> ConnectAddressWithStudent(int idStudent, int idAddress)
        {
            Student studentUpdated = await _dbContext.Student.FirstOrDefaultAsync(s => s.IdStudent == idStudent);
            if (studentUpdated == null)
            {
                throw new HttpRequestException("Student not found!", null, HttpStatusCode.NotFound);
            }

            Address address = await _dbContext.Address.FirstOrDefaultAsync(a => a.IdAddress == idAddress);
            if (address == null)
            {
                throw new HttpRequestException("Address not found!", null, HttpStatusCode.NotFound);
            }

            studentUpdated.IdAddress = address.IdAddress;
            studentUpdated.Address = address;

            await _dbContext.SaveChangesAsync();

            return studentUpdated;
        }
    }
}
