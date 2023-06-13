using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
	public interface IExerciseRepository : IBaseRepository<Exercise>
	{
		Task<Exercise> GetByDescription(string description);
	}
}
