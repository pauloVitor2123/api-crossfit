using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.DTO;
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

        [HttpGet("{idStudentPoints}")]
        [Authorize]
        public async Task<ActionResult<StudentPoints>> GetStudentPointsById(int idStudentPoints)
        {
            try
            {
                StudentPoints studentPoints = await _studentPointsRepository.GetById(idStudentPoints);
                return Ok(studentPoints);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{idStudent}/{idExercise}")]
        [Authorize]
        public async Task<ActionResult<StudentPoints>> GetListStudentPointsByIds(int idStudent, int idExercise)
        {
            try
            {
                List<StudentPoints> studentPoints = await _studentPointsRepository.GetListByIds(idStudent, idExercise);
                return Ok(studentPoints);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("byStudent/{idStudent}")]
        [Authorize]
        public async Task<ActionResult<List<StudentPoints>>> GetListStudentPointsByIdStudent(int idStudent)
        {
            try
            {
                List<StudentPointsWithExerciseNameDTO> studentPoints = await _studentPointsRepository.GetListByIdStudent(idStudent);
                return Ok(studentPoints);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("byExercise/{idExercise}")]
        [Authorize]
        public async Task<ActionResult<List<StudentPoints>>> GetListStudentPointsByIdExercise(int idExercise)
        {
            try
            {
                List<StudentPoints> studentPoints = await _studentPointsRepository.GetListByIdExercise(idExercise);
                return Ok(studentPoints);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("total/{idStudent}/{idExercise}")]
        [Authorize]
        public async Task<ActionResult<int>> GetTotalStudentPointsByIds(int idStudent, int idExercise)
        {
            try
            {
                int totalStudentPoints = await _studentPointsRepository.GetTotalPointsByIds(idStudent, idExercise);
                return Ok(totalStudentPoints);
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
                int totalStudentPoints = await _studentPointsRepository.GetTotalPointsByIdStudent(idStudent);
                return Ok(totalStudentPoints);
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

        [HttpPut("{idStudentPoints}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<StudentPoints>> UpdateStudentPoints(int idStudentPoints, [FromBody] StudentPointsRequest requestBody)
        {
            try
            {
                StudentPoints e = await _studentPointsRepository.Update(requestBody, idStudentPoints);
                return Ok(e);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{idStudentPoints}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<StudentPoints>> DeleteStudentPointsById(int idStudentPoints)
        {
            try
            {
                Boolean deleted = await _studentPointsRepository.Delete(idStudentPoints);
                return Ok(deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
