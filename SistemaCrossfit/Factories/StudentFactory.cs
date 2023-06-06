using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
    public class StudentFactory
    {
        public static List<Student> CreateSeedStudents()
        {
            List<Student> profiles = new List<Student>();

            Student student = new()
            {
                IdUser = 2,
                IdGenre = 1,
                BirthDate = DateTime.Now
            };
            profiles.Add(student);


            return profiles;
        }
    }
}
