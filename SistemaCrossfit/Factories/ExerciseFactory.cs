using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
	public class ExerciseFactory
	{
		public static List<Exercise> CreateSeedExercises()
		{
			List<Exercise> exercises = new();

			Exercise exercise1 = new()
			{
				Description = "Exercício Teste 1"
			};
			exercises.Add(exercise1);

			Exercise exercise2 = new()
			{
				Description = "Exercício 2"
			};
			exercises.Add(exercise2);

			return exercises;
		}
	}
}
