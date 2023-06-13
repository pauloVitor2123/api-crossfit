using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Controllers
{
	[Route("api/exercise")]
	[ApiController]
	public class ExerciseController : ControllerBase
	{
		private readonly IExerciseRepository _exerciseRepository;

		public ExerciseController(IExerciseRepository exerciseRepository)
		{
			_exerciseRepository = exerciseRepository;
		}

		[HttpGet]
		[Authorize]
		public async Task<ActionResult<List<Exercise>>> GetExercises()
		{
			List<Exercise> exercises = await _exerciseRepository.GetAll();
			return Ok(exercises);
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<Exercise>> GetExerciseById(int id)
		{
			Exercise exercise = await _exerciseRepository.GetById(id);
			return Ok(exercise);
		}

		[HttpPost]
		[Authorize(Roles = "ADMIN")]
		public async Task<ActionResult<Exercise>> CreateExercise([FromBody] Exercise exercise)
		{
			Exercise e = await _exerciseRepository.Create(exercise);
			return Ok(e);
		}

		[HttpPut("{id}")]
		[Authorize(Roles = "ADMIN")]
		public async Task<ActionResult<Exercise>> UpdateExercise(int id, [FromBody] Exercise exercise)
		{
			Exercise e = await _exerciseRepository.Update(exercise, id);
			return Ok(e);
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "ADMIN")]
		public async Task<ActionResult<Exercise>> DeleteExerciseById(int id)
		{
			Boolean deleted = await _exerciseRepository.Delete(id);
			return Ok(deleted);
		}
	}
}
