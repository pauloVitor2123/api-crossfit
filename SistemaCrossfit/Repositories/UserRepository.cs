using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.DTO.User;
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

        public async Task<User> Create(User user, string normalizedNameProfile)
        {
            Profile profile = await _dbContext.Profile.FirstOrDefaultAsync(s => s.NormalizedName == normalizedNameProfile);
            if (profile == null)
            {
                throw new Exception("Profile not found!");
            }

            user.IdProfile = profile.IdProfile;

            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(int id)
        {
            User user = await _dbContext.User.FirstOrDefaultAsync(user => user.IdUser == id);
            if (user == null)
            {
                throw new Exception("User not found!");
            }

            _dbContext.User.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> GetById(int id)
        {
            User user = await _dbContext.User.FirstOrDefaultAsync(user => user.IdUser == id);
            if (user == null)
            {
                throw new Exception("User not found!");
            }
            return user;
        }

        public async Task<dynamic> Login(LoginInput login)
        {
            User user = await _dbContext.User.FirstOrDefaultAsync(u => u.Email == login.Email);
            if (user == null)
            {
                throw new Exception("Email or password not found!");
            }

            Profile profile = await _dbContext.Profile.FirstOrDefaultAsync(profile => profile.IdProfile == user.IdProfile);
            if (profile == null)
            {
                throw new Exception("profile not found!");
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
