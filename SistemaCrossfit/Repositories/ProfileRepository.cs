using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AppDBContext _dbContext;
        public ProfileRepository(AppDBContext appDbContext) {
            _dbContext = appDbContext;
        }
      
        public async Task<List<ProfileModel>> GetAll()
        {
            return await _dbContext.Profile.ToListAsync();
        }

        public async Task<ProfileModel> GetById(int id)
        {
            ProfileModel profile = await _dbContext.Profile.FirstOrDefaultAsync(profile => profile.IdProfile == id);
            if(profile == null)
            {
                throw new Exception("User not found!");
            }

            return profile;
        }

        public async Task<ProfileModel> Create(ProfileModel profile)
        {
            await _dbContext.Profile.AddAsync(profile);
            await _dbContext.SaveChangesAsync();
            return profile;
        }

        public async Task<ProfileModel> Update(ProfileModel profile, int id)
        {
            ProfileModel profileUpdated = await _dbContext.Profile.FirstOrDefaultAsync(p => p.IdProfile == id);
            if (profileUpdated == null)
            {
                throw new Exception("User not found!");
            }

            profileUpdated.NormalizedName = profile.NormalizedName;
            profileUpdated.Name = profile.Name;

            await _dbContext.SaveChangesAsync();

            return profileUpdated;
        }

        public async Task<Boolean> Delete(int id)
        {
            ProfileModel profile = await _dbContext.Profile.FirstOrDefaultAsync(profile => profile.IdProfile == id);
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
