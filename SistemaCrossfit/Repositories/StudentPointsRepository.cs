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

		public async Task<List<StudentPoints>> GetAll()
		{
			List<StudentPoints> studentPoints = await _dbContext.StudentPoints.ToListAsync();

			if (studentPoints == null || studentPoints.Count == 0)
			{
				throw new Exception("There are no StudentPoints registered!");
			}

			return studentPoints;
		}

		public async Task<StudentPoints> GetById(int idStudentPoints)
		{
			StudentPoints? studentPoints = await _dbContext.StudentPoints.FirstOrDefaultAsync(x => x.IdStudentPoints == idStudentPoints);

			if (studentPoints == null)
			{
				throw new Exception("StudentPoints not found!");
			}

			return studentPoints;
		}

		public async Task<List<StudentPoints>> GetListByIds(int idStudent, int idExercise)
		{
			List<StudentPoints>? studentPoints = await _dbContext.StudentPoints.Where(x => x.IdStudent == idStudent && x.IdExercise == idExercise).ToListAsync();

			if (studentPoints == null || studentPoints.Count == 0)
			{
				throw new Exception("StudentPoints not found!");
			}

			return studentPoints;
		}

		public async Task<List<StudentPoints>> GetListByIdStudent(int idStudent)
		{
			List<StudentPoints>? studentPoints = await _dbContext.StudentPoints.Where(x => x.IdStudent == idStudent).ToListAsync();

			if (studentPoints == null || studentPoints.Count == 0)
			{
				throw new Exception("StudentPoints not found!");
			}

			return studentPoints;
		}

		public async Task<List<StudentPoints>> GetListByIdExercise(int idExercise)
		{
			List<StudentPoints>? studentPoints = await _dbContext.StudentPoints.Where(x => x.IdExercise == idExercise).ToListAsync();

			if (studentPoints == null || studentPoints.Count == 0)
			{
				throw new Exception("StudentPoints not found!");
			}

			return studentPoints;
		}

		public async Task<int> GetTotalPointsByIds(int idStudent, int idExercise)
		{
			List<StudentPoints>? studentPoints = await GetListByIds(idStudent, idExercise);

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

		public async Task<int> GetTotalPointsByIdStudent(int idStudent)
		{
			List<StudentPoints>? studentPoints = await GetListByIdStudent(idStudent);

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

		public async Task<StudentPoints> Create(StudentPointsRequest requestBody)
		{
			try
			{
				if (!requestBody.IdStudent.HasValue || !requestBody.IdExercise.HasValue)
				{
					throw new Exception("Student and Exercise ids are required!");
				}

				if (!requestBody.Points.HasValue)
				{
					throw new Exception("Points is required!");
				}

				StudentPoints studentPoints = new()
				{
					IdStudent = (int) requestBody.IdStudent,
					IdExercise = (int) requestBody.IdExercise,
					Points = (int) requestBody.Points
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

		public async Task<StudentPoints> Update(StudentPointsRequest requestBody, int idStudentPoints)
		{
			try
			{
				StudentPoints? studentPointsUpdated = await _dbContext.StudentPoints.FirstOrDefaultAsync(s => s.IdStudentPoints == idStudentPoints);
				if (studentPointsUpdated == null)
				{
					throw new Exception("StudentPoints not found!");
				}

				if (!requestBody.IdStudent.HasValue && !requestBody.IdExercise.HasValue && !requestBody.Points.HasValue)
				{
					throw new Exception("Nothing was changed!");
				}

				if (requestBody.IdStudent.HasValue)
				{
					studentPointsUpdated.IdStudent = (int) requestBody.IdStudent;
				}

				if (requestBody.IdExercise.HasValue)
				{
					studentPointsUpdated.IdExercise = (int) requestBody.IdExercise;
				}

				if (requestBody.Points.HasValue)
				{
					studentPointsUpdated.Points = (int) requestBody.Points;
				}

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

		public async Task<bool> Delete(int idStudentPoints)
		{
			try
			{
				StudentPoints? studentPoints = await _dbContext.StudentPoints.FirstOrDefaultAsync(s => s.IdStudentPoints == idStudentPoints);
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
