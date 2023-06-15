using SistemaCrossfit.Models;
using SistemaCrossfit.Request;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IStudentPointsRepository
    {
        Task<List<StudentPoints>> GetAll();
        Task<StudentPoints> GetByIds(int idStudent, int idExercise);
        Task<StudentPoints> Create(StudentPointsRequest requestBody);
        Task<StudentPoints> Update(StudentPointsRequest requestBody, int idStudent, int idExercise);
        Task<Boolean> Delete(int idStudent, int idExercise);
    }
}
