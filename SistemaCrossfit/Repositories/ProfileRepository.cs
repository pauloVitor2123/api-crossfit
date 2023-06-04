using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class ProfileRepository : IBaseRepository<Profile>
    {
        private readonly AppDBContext _dbContext;
        public ProfileRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<Profile>> GetAll()
        {
            return await _dbContext.Profile.ToListAsync();
        }

        public async Task<Profile> GetById(int id)
        {
            Profile profile = await _dbContext.Profile.FirstOrDefaultAsync(profile => profile.IdProfile == id);
            if (profile == null)
            {
                throw new Exception("User not found!");
            }

            return profile;
        }

        public async Task<Profile> Create(Profile profile)
        {
            await _dbContext.Profile.AddAsync(profile);
            await _dbContext.SaveChangesAsync();
            return profile;
        }

        public async Task<Profile> Update(Profile profile, int id)
        {
            Profile profileUpdated = await _dbContext.Profile.FirstOrDefaultAsync(p => p.IdProfile == id);
            if (profileUpdated == null)
            {
                throw new Exception("User not found!");
            }

            profileUpdated.NormalizedName = profile.NormalizedName;
            profileUpdated.Name = profile.Name;
            profileUpdated.Active = profile.Active;

            await _dbContext.SaveChangesAsync();

            return profileUpdated;
        }

        public async Task<Boolean> Delete(int id)
        {
            Profile profile = await _dbContext.Profile.FirstOrDefaultAsync(profile => profile.IdProfile == id);
            if (profile == null)
            {
                throw new Exception("User not found!");
            }

            _dbContext.Profile.Remove(profile);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
