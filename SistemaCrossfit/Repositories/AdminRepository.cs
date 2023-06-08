using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDBContext _dbContext;
        public AdminRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<CreateAdminBody>> GetAllAdmins()
        {
            UserRepository userRepository = new UserRepository(_dbContext);
            List<Admin> admins = await _dbContext.Admin.ToListAsync();
            List<CreateAdminBody> adminList = new List<CreateAdminBody>();
            foreach (var admin in admins)
            {
                User user = await userRepository.GetById(admin.IdUser);
                CreateAdminBody adminBody = new CreateAdminBody(user, admin.IdAdmin);
                adminList.Add(adminBody);
            }


            return adminList;
        }

        public async Task<int> DeleteReturningIdUser(int id)
        {
            Admin admin = await _dbContext.Admin.FirstOrDefaultAsync(a => a.IdAdmin == id);
            if (admin == null)
            {
                throw new Exception("Admin not found!");
            }

            int IdUser = admin.IdUser;

            _dbContext.Admin.Remove(admin);
            await _dbContext.SaveChangesAsync();


            return IdUser;
        }


        public async Task<Admin> Create(Admin admin)
        {
            await _dbContext.Admin.AddAsync(admin);
            await _dbContext.SaveChangesAsync();

            return admin;
        }

        public Task<Admin> Update(Admin entityModel, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Admin> GetById(int id)
        {
            Admin admin = await _dbContext.Admin.FirstOrDefaultAsync(a => a.IdAdmin == id);
            if (admin == null)
            {
                throw new Exception("Admin not found!");
            }

            return admin;
        }


        public Task<List<Admin>> GetAll()
        {
            throw new NotImplementedException();
        }
        Task<bool> IBaseRepository<Admin>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
