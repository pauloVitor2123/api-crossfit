using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IBaseRepository<Genre> _genreRepository;
        public GenreController(IBaseRepository<Genre> GenreRepository)
        {
            this._genreRepository = GenreRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Genre>>> GetGenres()
        {
            List<Genre> genres = await _genreRepository.GetAll();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenreById(int id)
        {
            Genre genre = await _genreRepository.GetById(id);
            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> CreateGenre([FromBody] Genre Genre)
        {
            Genre g = await _genreRepository.Create(Genre);
            return Ok(g);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Genre>> UpdatedGenre(int id, [FromBody] Genre genre)
        {
            Genre g = await _genreRepository.Update(genre, id);
            return Ok(g);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Genre>> DeleteGenreById(int id)
        {
            Boolean deleted = await _genreRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
