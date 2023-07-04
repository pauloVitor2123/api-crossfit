using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;
using SistemaCrossfit.Request;

namespace SistemaCrossfit.Controllers
{
	[Route("api/studentPoints")]
	[ApiController]
	public class StudentPointsController : ControllerBase
	{
		private readonly IStudentPointsRepository _studentPointsRepository;

		public StudentPointsController(IStudentPointsRepository studentPointsRepository)
		{
			_studentPointsRepository = studentPointsRepository;
		}

		[HttpGet]
		[Authorize]
		public async Task<ActionResult<List<StudentPoints>>> GetStudentPoints()
		{
			try
			{
				List<StudentPoints> studentPoints = await _studentPointsRepository.GetAll();
				return Ok(studentPoints);
			}
			catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}

		[HttpGet("{idStudent}")]
		[Authorize]
		public async Task<ActionResult<List<StudentPoints>>> GetStudentPointsByIdStudent(int idStudent)
		{
			try
			{
				List<StudentPoints> studentPoints = await _studentPointsRepository.GetStudentPointsByIdStudent(idStudent);
				return Ok(studentPoints);
			}
			catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}

		[HttpGet("total/{idStudent}")]
		[Authorize]
		public async Task<ActionResult<int>> GetTotalStudentPointsByIdStudent(int idStudent)
		{
			try
			{
				int totalStudentPoints = await _studentPointsRepository.GetTotalStudentPointsByIdStudent(idStudent);
				return Ok(totalStudentPoints);
			}
			catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}

		[HttpGet("{idStudent}/{idExercise}")]
		[Authorize]
		public async Task<ActionResult<StudentPoints>> GetStudentPointsByIds(int idStudent, int idExercise)
		{
			try
			{
				StudentPoints studentPoints = await _studentPointsRepository.GetByIds(idStudent, idExercise);
				return Ok(studentPoints);
			}
			catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult<StudentPoints>> CreateStudentPoints([FromBody] StudentPointsRequest requestBody)
		{
			try
			{
				StudentPoints e = await _studentPointsRepository.Create(requestBody);
				return Ok(e);
			}
			catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}

		[HttpPut("{idStudent}/{idExercise}")]
		[Authorize(Roles = "ADMIN")]
		public async Task<ActionResult<StudentPoints>> UpdateStudentPoints(int idStudent, int idExercise, [FromBody] StudentPointsRequest requestBody)
		{
			try
			{
				StudentPoints e = await _studentPointsRepository.Update(requestBody, idStudent, idExercise);
				return Ok(e);
			}
			catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}

		[HttpDelete("{idStudent}/{idExercise}")]
		[Authorize(Roles = "ADMIN")]
		public async Task<ActionResult<StudentPoints>> DeleteStudentPointsById(int idStudent, int idExercise)
		{
			try
			{
				Boolean deleted = await _studentPointsRepository.Delete(idStudent, idExercise);
				return Ok(deleted);
			}
			catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}
	}
}
