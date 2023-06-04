using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IBaseRepository<Genre> _GenreRepository;
        public GenreController(IBaseRepository<Genre> GenreRepository)
        {
            this._GenreRepository = GenreRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Genre>>> GetGenres()
        {
            List<Genre> Genres = await _GenreRepository.GetAll();
            return Ok(Genres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenreById(int id)
        {
            Genre Genre = await _GenreRepository.GetById(id);
            return Ok(Genre);
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> Create([FromBody] Genre Genre)
        {
            Genre p = await _GenreRepository.Create(Genre);
            return Ok(p);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Genre>> UpdatedGenre(int id, [FromBody] Genre Genre)
        {
            Genre g = await _GenreRepository.Update(Genre, id);
            return Ok(g);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Genre>> DeleteById(int id)
        {
            Boolean deleted = await _GenreRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
