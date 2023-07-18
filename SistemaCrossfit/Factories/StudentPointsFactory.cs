using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
    public class StudentPointsFactory
    {
        public static List<StudentPoints> CreateSeedStudentPoints()
        {
            List<StudentPoints> studentPointsList = new List<StudentPoints>();

            StudentPoints studentPoints1 = new()
            {
                IdStudent = 1,
                IdExercise = 1,
                Points = 100
            };
            studentPointsList.Add(studentPoints1);

            StudentPoints studentPoints2 = new()
            {
                IdStudent = 1,
                IdExercise = 2,
                Points = 90
            };
            studentPointsList.Add(studentPoints2);

			StudentPoints studentPoints3 = new()
            {
                IdStudent = 1,
                IdExercise = 1,
                Points = 120
            };
            studentPointsList.Add(studentPoints3);

            return studentPointsList;
        }
    }
}
