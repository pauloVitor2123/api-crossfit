using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
    public class StudentFactory
    {
        public static List<Student> CreateSeedStudents()
        {
            List<Student> students = new List<Student>();

            Student student = new()
            {
                IdUser = 2,
                IdGender = 1,
                BirthDate = DateTime.Now
            };
            students.Add(student);


            return students;
        }
    }
}
