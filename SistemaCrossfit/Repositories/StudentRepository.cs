using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Migrations;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;
using SistemaCrossfit.Request;
using SistemaCrossfit.Services;
using System.Net;

namespace SistemaCrossfit.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDBContext _dbContext;
        private readonly PaymentService paymentService;
        public StudentRepository(AppDBContext appDbContext, PaymentService paymentService)
        {
            _dbContext = appDbContext;
            this.paymentService = paymentService;
        }

        public async Task<List<CreateStudentBody>> GetAll()
        {
            UserRepository userRepository = new UserRepository(_dbContext);
            List<Student> students = await _dbContext.Student.ToListAsync();
            List<CreateStudentBody> studentsList = new List<CreateStudentBody>();
            foreach (var student in students)
            {
                User user = await userRepository.GetById(student.IdUser);
                CreateStudentBody studentBody = new CreateStudentBody(user, student);
                studentsList.Add(studentBody);
            }


            return studentsList;
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

            var user =  await _dbContext.Student.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            await paymentService.CreatePayment(new CreatePaymentRequest()
            {
                IdAdmin = null,
                IdStudent = user.Entity.IdStudent
            });

            return student;
        }

        public async Task<Student> Update(Student student, int id)
        {
            Student studentUpdated = await _dbContext.Student.FirstOrDefaultAsync(s => s.IdStudent == id);
            if (studentUpdated == null)
            {
                throw new Exception("Student not found!");
            }

            studentUpdated.IdAddress = student.IdAddress;
            studentUpdated.IdGenre = student.IdGenre;
            studentUpdated.BirthDate = student.BirthDate;

            await _dbContext.SaveChangesAsync();
            return studentUpdated;
        }

        public async Task<int> DeleteReturningIdUser(int id)
        {
            Student student = await _dbContext.Student.FirstOrDefaultAsync(student => student.IdStudent == id);
            if (student == null)
            {
                throw new Exception("Student not found!");
            }

            int IdUser = student.IdUser;

            _dbContext.Student.Remove(student);
            await _dbContext.SaveChangesAsync();

            return IdUser;
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
