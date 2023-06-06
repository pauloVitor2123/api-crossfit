using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _dbContext;
        public UserRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public Task<User> login(User user)
        {
            throw new NotImplementedException();
        }


        /*public async Task<User> login(User user)
        {
            User user = await _dbContext.User.FirstOrDefaultAsync(user => user.IdStudent == id);
            if (user == null)
            {
                throw new Exception("Student not found!");
            }

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user,
                token
            }
        }*/
    }
}
