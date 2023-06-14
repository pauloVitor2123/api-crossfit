using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class ClassRepository : IClassRespository
    {
        private readonly AppDBContext _dbContext;

        public ClassRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Class>> GetAll()
        {
            return await _dbContext.Class.ToListAsync();
        }

        public async Task<Class> GetByName(string name)
        {
            var className = await _dbContext.Class.FirstOrDefaultAsync(c => c.Name == name);
            
            return className == null ? throw new Exception("Class not found!") : className;
        }

        public async Task<Class> GetById(int id)
        {
            var classId = await _dbContext.Class.FirstOrDefaultAsync(c => c.IdClass == id);

            return classId == null ? throw new Exception("Class not found!") : classId;
        }

        public async Task<Class> Create(Class classCreate)
        {
            await _dbContext.Class.AddAsync(classCreate);
            await _dbContext.SaveChangesAsync();

            return classCreate;
        }

        public async Task<Class> Update(Class classEntity, int id)
        {
            var classUpdate = await _dbContext.Class.FirstOrDefaultAsync(c => c.IdClass == id);
            if (classUpdate == null) throw new Exception("Class not found!");
            
            classUpdate.Name = classEntity.Name;
            classUpdate.Description = classEntity.Description;
            await _dbContext.SaveChangesAsync();

            return classUpdate;
        }

        public async Task<bool> Delete(int id)
        {
            var classDelete = await _dbContext.Class.FirstOrDefaultAsync(c => c.IdClass == id);
            if (classDelete == null) throw new Exception("Class not found!");

            _dbContext.Class.Remove(classDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}