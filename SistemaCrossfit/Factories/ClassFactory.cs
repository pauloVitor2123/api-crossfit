using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
    public class ClassFactory
    {
        public static List<Class> CreateSeedClasses()
        {
            var classes = new List<Class>();

            var classCross = new Class() 
            {
                IdStatus = 1,
                IdProfessor = 1,
                Name = "CrossFit",
                StartHour = new TimeSpan(8, 0, 0),
                EndHour = new TimeSpan(10, 30, 0),
                Description = "Aula de força fisica e treinamento",
                Date = new DateTime().AddDays(1),
            };
            classes.Add(classCross);

            return classes;
        }
    }
}