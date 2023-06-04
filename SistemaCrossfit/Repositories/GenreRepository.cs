using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class GenreRepository : IBaseRepository<Genre>
    {
        private readonly AppDBContext _dbContext;
        public GenreRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<Genre>> GetAll()
        {
            return await _dbContext.Genre.ToListAsync();
        }

        public async Task<Genre> GetById(int id)
        {
            Genre genre = await _dbContext.Genre.FirstOrDefaultAsync(genre => genre.IdGenre == id);
            if (genre == null)
            {
                throw new Exception("User not found!");
            }

            return genre;
        }

        public async Task<Genre> Create(Genre Genre)
        {
            await _dbContext.Genre.AddAsync(Genre);
            await _dbContext.SaveChangesAsync();
            return Genre;
        }

        public async Task<Genre> Update(Genre genre, int id)
        {
            Genre genreUpdated = await _dbContext.Genre.FirstOrDefaultAsync(p => p.IdGenre == id);
            if (genreUpdated == null)
            {
                throw new Exception("User not found!");
            }

            genreUpdated.NormalizedName = genre.NormalizedName;
            genreUpdated.Name = genre.Name;

            await _dbContext.SaveChangesAsync();

            return genreUpdated;
        }

        public async Task<Boolean> Delete(int id)
        {
            Genre genre = await _dbContext.Genre.FirstOrDefaultAsync(genre => genre.IdGenre == id);
            if (genre == null)
            {
                throw new Exception("User not found!");
            }

            _dbContext.Genre.Remove(genre);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
