using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;
using SistemaCrossfit.Services;

namespace SistemaCrossfit.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _dbContext;

        public UserRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<User>> GetAll()
        {
            List<User> users = await _dbContext.User.ToListAsync();

            foreach (var user in users)
            {
                var profile = await _dbContext.Profile.FirstOrDefaultAsync(profile => profile.IdProfile == user.IdProfile);
                if (profile == null)
                {
                    throw new Exception("Profile not found!");
                }
                user.Profile = profile;
            }
            return users;
        }

        public async Task<User> Create(User user)
        {
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(User user)
        {
            var userUpdated = await _dbContext.User.FirstOrDefaultAsync(u => u.IdUser == user.IdUser);

            if (userUpdated == null)
            {
                throw new Exception("User not found!");
            }

            userUpdated.Email = user.Email;
            if (user.Password != "")
            {
                userUpdated.Password = user.Password;
            }
            userUpdated.Name = user.Name;
            userUpdated.SocialName = user.SocialName;

            await _dbContext.SaveChangesAsync();

            return user;
        }

        private async Task deleteAdminByIdUser(int IdUser)
        {
            AdminRepository adminRepository = new AdminRepository(_dbContext);
            var admin = await _dbContext.Admin.FirstOrDefaultAsync(admin => admin.IdUser == IdUser);
            if (admin == null)
            {
                throw new Exception("Admin not found!");
            }
            await adminRepository.DeleteReturningIdUser(admin.IdAdmin);
        }
        private async Task deleteStudentByIdUser(int IdUser)
        {
            PaymentService paymentService = new PaymentService(_dbContext);
            StudentRepository studentRepository = new StudentRepository(_dbContext, paymentService);
            var student = await _dbContext.Student.FirstOrDefaultAsync(student => student.IdUser == IdUser);
            if (student == null)
            {
                throw new Exception("Student not found!");
            }
            await studentRepository.DeleteReturningIdUser(student.IdStudent);
        }

        private async Task deleteProfessorByIdUser(int IdUser)
        {
            ProfessorRepository professorRepository = new ProfessorRepository(_dbContext);
            var professor = await _dbContext.Professor.FirstOrDefaultAsync(professor => professor.IdUser == IdUser);
            if (professor == null)
            {
                throw new Exception("Professor not found!");
            }
            await professorRepository.DeleteReturningIdUser(professor.IdProfessor);
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(user => user.IdUser == id);
            if (user == null)
            {
                throw new Exception("User not found!");
            }


            var profile = await _dbContext.Profile.FirstOrDefaultAsync(profile => profile.IdProfile == user.IdProfile);
            if (profile == null)
            {
                throw new Exception("Profile not found!");
            }
            if (profile.NormalizedName == "ADMIN")
            {
                await this.deleteAdminByIdUser(id);
            }
            else if (profile.NormalizedName == "STUDENT")
            {
                await this.deleteStudentByIdUser(id);
            }
            else if (profile.NormalizedName == "PROFESSOR")
            {
                await this.deleteProfessorByIdUser(id);

            }


            _dbContext.User.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(user => user.IdUser == id);
            if (user == null)
            {
                throw new Exception("User not found!");
            }
            return user;
        }
        public async Task<Professor> GetProfessorByIdUser(int idUser)
        {
            var professor = await _dbContext.Professor.FirstOrDefaultAsync(professor => professor.IdUser == idUser);
            if (professor == null)
            {
                throw new Exception("Professor not found!");
            }
            return professor;
        }
        public async Task<Admin> GetAdminByIdUser(int idUser)
        {
            var admin = await _dbContext.Admin.FirstOrDefaultAsync(admin => admin.IdUser == idUser);
            if (admin == null)
            {
                throw new Exception("Admin not found!");
            }
            return admin;
        }
        public async Task<Student> GetStudentByIdUser(int idUser)
        {
            var student = await _dbContext.Student.FirstOrDefaultAsync(student => student.IdUser == idUser);
            if (student == null)
            {
                throw new Exception("Student not found!");
            }
            return student;
        }


        public async Task<dynamic> Login(LoginBody login)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);
            if (user == null)
            {
                throw new Exception("Email or password not found!");
            }

            var profile = await _dbContext.Profile.FirstOrDefaultAsync(profile => profile.IdProfile == user.IdProfile);
            if (profile == null)
            {
                throw new Exception("Profile not found!");
            }


            var student = await _dbContext.Student.FirstOrDefaultAsync(student => student.IdUser == user.IdUser);
            if (student != null)
            {

                var payment = await _dbContext.Payment
                                .Where(x => x.IdStudent == student.IdStudent)
                                .OrderByDescending(x => x.IdPayment)
                                .LastOrDefaultAsync();
                if (payment == null)
                {
                    throw new Exception("Payment not found!");
                }

                var status = await _dbContext.Status.FirstOrDefaultAsync(s => s.IdStatus == payment.IdStatus);
                if (status == null)
                {
                    throw new Exception("Status not found!");
                }


                if (status.NormalizedName == "PENDENT" && payment.DatePayment == null && DateTime.Now > payment.DueDate)
                {
                    PaymentService paymentService = new PaymentService(_dbContext);
                    StudentRepository studentRepository = new StudentRepository(_dbContext, paymentService);

                    await studentRepository.Block(student.IdStudent, "Você possui uma fatura em aberto que precisa ser quitada.");
                }

            }

            var token = TokenService.GenerateToken(user, profile);
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }


    }
}
