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
            UserRepository userRepository = new UserRepository(_dbContext);
            List<Student> studentList = await _dbContext.Student.ToListAsync();
            foreach (var student in studentList)
            {
                student.User = await userRepository.GetById(student.IdUser);
            }


            return studentList;
        }

        public async Task<Student> GetById(int id)
        {
            Student student = await _dbContext.Student.FirstOrDefaultAsync(student => student.IdStudent == id);
            if (student == null)
            {
                throw new Exception("Student not found!");
            }

            User user = await _dbContext.User.FirstOrDefaultAsync(user => user.IdUser == student.IdUser);
            if (user == null)
            {
                throw new Exception("User not found!");
            }

            student.User = user;
            return student;
        }

        public async Task<Student> Create(CreateStudent httpStudent)
        {

            User user = new User();
            user.Name = httpStudent.Name;
            user.Email = httpStudent.Email;
            user.Password = httpStudent.Password;
            user.SocialName = httpStudent.SocialName;

            UserRepository userRepository = new UserRepository(_dbContext);
            User userInserted = await userRepository.Create(user, "STUDENT");

            Student student = new Student();
            student.IdAddress = httpStudent.IdAddress;
            student.IdGenre = httpStudent.IdGenre;
            student.BirthDate = httpStudent.BirthDate;
            student.IdUser = userInserted.IdUser;
            student.User = userInserted;

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

            User userUpdated = await _dbContext.User.FirstOrDefaultAsync(s => s.IdUser == studentUpdated.IdUser);
            if (userUpdated == null)
            {
                throw new Exception("User not found!");
            }


            userUpdated.Name = httpStudent.Name;
            userUpdated.Email = httpStudent.Email;
            userUpdated.Password = httpStudent.Password;
            userUpdated.SocialName = httpStudent.SocialName;


            studentUpdated.IdAddress = httpStudent.IdAddress;
            studentUpdated.IdGenre = httpStudent.IdGenre;
            studentUpdated.BirthDate = httpStudent.BirthDate;

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


            UserRepository userRepository = new UserRepository(_dbContext);
            await userRepository.Delete(student.IdUser);

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
