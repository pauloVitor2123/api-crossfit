using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
    public class ProfessorFactory
    {
        public static List<Professor> CreateSeedProfessors()
        {
            List<Professor> professors = new List<Professor>();

            Professor professor = new()
            {
                IdUser = 3
            };
            professors.Add(professor);

            return professors;
        }
    }
}