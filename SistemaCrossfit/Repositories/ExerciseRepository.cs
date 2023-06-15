using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
	public class ExerciseRepository : IExerciseRepository
	{
		private readonly AppDBContext _dbContext;
		public ExerciseRepository(AppDBContext appDBContext)
		{
			_dbContext = appDBContext;
		}

		public async Task<List<Exercise>> GetAll()
		{
			return await _dbContext.Exercise.ToListAsync();
		}

		public async Task<Exercise> GetById(int id)
		{
			Exercise? exercise = await _dbContext.Exercise.FirstOrDefaultAsync(e => e.IdExercise == id);
			if (exercise == null)
			{
				throw new Exception("Exercise not found!");
			}

			return exercise;
		}

		public async Task<Exercise> Create(Exercise exercise)
		{
			try
			{
				await _dbContext.Exercise.AddAsync(exercise);
				await _dbContext.SaveChangesAsync();
				return exercise;
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

		public async Task<Exercise> Update(Exercise exercise, int id)
		{
			try
			{
				Exercise? exerciseUpdated = await _dbContext.Exercise.FirstOrDefaultAsync(e => e.IdExercise == id);
				if (exerciseUpdated == null)
				{
					throw new Exception("Exercise not found!");
				}

				exerciseUpdated.Description = exercise.Description;

				await _dbContext.SaveChangesAsync();

				return exerciseUpdated;
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

		public async Task<bool> Delete(int id)
		{
			try
			{
				Exercise? exercise = await _dbContext.Exercise.FirstOrDefaultAsync(e => e.IdExercise == id);
				if (exercise == null)
				{
					throw new Exception("Exercise not found!");
				}

				_dbContext.Exercise.Remove(exercise);
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

		public async Task<Exercise> GetByDescription(string description)
		{
			Exercise? exercise = await _dbContext.Exercise.FirstOrDefaultAsync(e => e.Description == description);
			if (exercise == null)
			{
				throw new Exception("Exercise not found!");
			}

			return exercise;
		}
	}
}
