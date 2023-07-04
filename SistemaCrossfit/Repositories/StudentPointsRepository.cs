using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;
using SistemaCrossfit.Request;

namespace SistemaCrossfit.Repositories
{
	public class StudentPointsRepository : IStudentPointsRepository
    {
        private readonly AppDBContext _dbContext;
        public StudentPointsRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

		public async Task<List<StudentPoints>> GetAll() {
			return await _dbContext.StudentPoints.ToListAsync();
		}

		public async Task<List<StudentPoints>> GetStudentPointsByIdStudent(int idStudent)
		{
			List<StudentPoints>? studentPoints = await _dbContext.StudentPoints.Where(x => x.IdStudent == idStudent).ToListAsync();

			if (studentPoints == null || studentPoints.Count == 0)
			{
				throw new Exception("StudentPoints not found!");
			}

			return studentPoints;
		}

		public async Task<int> GetTotalStudentPointsByIdStudent(int idStudent)
		{
			List<StudentPoints>? studentPoints = await GetStudentPointsByIdStudent(idStudent);

			if (studentPoints == null || studentPoints.Count == 0)
			{
				throw new Exception("StudentPoints not found!");
			}

			int totalPoints = 0;
			foreach (StudentPoints points in studentPoints)
			{
				totalPoints += points.Points;
			}

			return totalPoints;
		}

		public async Task<StudentPoints> GetByIds(int idStudent, int idExercise)
		{
			StudentPoints? studentPoints = await _dbContext.StudentPoints.FirstOrDefaultAsync(x => x.IdStudent == idStudent && x.IdExercise == idExercise);

			if (studentPoints == null)
			{
				throw new Exception("StudentPoints not found!");
			}

			return studentPoints;
		}

		public async Task<StudentPoints> Create(StudentPointsRequest requestBody)
		{
			try
			{
				if (!requestBody.IdStudent.HasValue || !requestBody.IdExercise.HasValue)
				{
					throw new Exception("Student and Exercise ids are required!");
				}

				StudentPoints studentPoints = new()
				{
					IdStudent = (int) requestBody.IdStudent,
					IdExercise = (int) requestBody.IdExercise,
					Points = requestBody.Points
				};

				await _dbContext.StudentPoints.AddAsync(studentPoints);
				await _dbContext.SaveChangesAsync();
				return studentPoints;
			}
			catch (Exception ex)
			{
				string msg = ex.Message;

				if (ex is DbUpdateException)
				{
					msg = ex.GetBaseException().Message;
				}

				throw new Exception(msg);
			}
		}

		public async Task<StudentPoints> Update(StudentPointsRequest requestBody, int idStudent, int idExercise)
		{
			try
			{
				StudentPoints? studentPointsUpdated = await _dbContext.StudentPoints.FirstOrDefaultAsync(s => s.IdStudent == idStudent && s.IdExercise == idExercise);
				if (studentPointsUpdated == null)
				{
					throw new Exception("StudentPoints not found!");
				}

				studentPointsUpdated.Points = requestBody.Points;

				await _dbContext.SaveChangesAsync();

				return studentPointsUpdated;
			}
			catch (Exception ex)
			{
				string msg = ex.Message;

				if (ex is DbUpdateException)
				{
					msg = ex.GetBaseException().Message;
				}

				throw new Exception(msg);
			}
		}

		public async Task<bool> Delete(int idStudent, int idExercise)
		{
			try
			{
				StudentPoints? studentPoints = await _dbContext.StudentPoints.FirstOrDefaultAsync(s => s.IdStudent == idStudent && s.IdExercise == idExercise);
				if (studentPoints == null)
				{
					throw new Exception("StudentPoints not found!");
				}

				_dbContext.StudentPoints.Remove(studentPoints);
				await _dbContext.SaveChangesAsync();

				return true;
			}
			catch (Exception ex)
			{
				string msg = ex.Message;

				if (ex is DbUpdateException)
				{
					msg = ex.GetBaseException().Message;
				}

				throw new Exception(msg);
			}
		}
	}
}
