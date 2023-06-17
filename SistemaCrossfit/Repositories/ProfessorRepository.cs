using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly AppDBContext _dbContext;
        public ProfessorRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<CreateProfessorBody>> GetAllProfessors()
        {
            UserRepository userRepository = new UserRepository(_dbContext);
            List<Professor> professors = await _dbContext.Professor.ToListAsync();
            List<CreateProfessorBody> professorList = new List<CreateProfessorBody>();
            foreach (var professor in professors)
            {
                User user = await userRepository.GetById(professor.IdUser);
                CreateProfessorBody professorBody = new CreateProfessorBody(user, professor.IdProfessor);
                professorList.Add(professorBody);
            }


            return professorList;
        }

        public async Task<int> DeleteReturningIdUser(int id)
        {
            Professor professor = await _dbContext.Professor.FirstOrDefaultAsync(a => a.IdProfessor == id);
            if (professor == null)
            {
                throw new Exception("Professor not found!");
            }

            int IdUser = professor.IdUser;

            _dbContext.Professor.Remove(professor);
            await _dbContext.SaveChangesAsync();


            return IdUser;
        }


        public async Task<Professor> Create(Professor professor)
        {
            await _dbContext.Professor.AddAsync(professor);
            await _dbContext.SaveChangesAsync();

            return professor;
        }

        public Task<Professor> Update(Professor entityModel, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Professor> GetById(int id)
        {
            Professor professor = await _dbContext.Professor.FirstOrDefaultAsync(a => a.IdProfessor == id);
            if (professor == null)
            {
                throw new Exception("Professor not found!");
            }

            return professor;
        }


        public Task<List<Professor>> GetAll()
        {
            throw new NotImplementedException();
        }
        Task<bool> IBaseRepository<Professor>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
