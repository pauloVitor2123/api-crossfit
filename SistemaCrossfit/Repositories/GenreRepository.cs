using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class GenderRepository : IBaseRepository<Gender>
    {
        private readonly AppDBContext _dbContext;
        public GenderRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<Gender>> GetAll()
        {
            return await _dbContext.Gender.ToListAsync();
        }

        public async Task<Gender> GetById(int id)
        {
            Gender gender = await _dbContext.Gender.FirstOrDefaultAsync(gender => gender.IdGender == id);
            if (gender == null)
            {
                throw new Exception("User not found!");
            }

            return gender;
        }

        public async Task<Gender> Create(Gender Gender)
        {
            await _dbContext.Gender.AddAsync(Gender);
            await _dbContext.SaveChangesAsync();
            return Gender;
        }

        public async Task<Gender> Update(Gender gender, int id)
        {
            Gender genderUpdated = await _dbContext.Gender.FirstOrDefaultAsync(p => p.IdGender == id);
            if (genderUpdated == null)
            {
                throw new Exception("User not found!");
            }

            genderUpdated.NormalizedName = gender.NormalizedName;
            genderUpdated.Name = gender.Name;

            await _dbContext.SaveChangesAsync();

            return genderUpdated;
        }

        public async Task<Boolean> Delete(int id)
        {
            Gender gender = await _dbContext.Gender.FirstOrDefaultAsync(gender => gender.IdGender == id);
            if (gender == null)
            {
                throw new Exception("User not found!");
            }

            _dbContext.Gender.Remove(gender);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
