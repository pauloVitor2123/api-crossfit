using SistemaCrossfit.Models;
using SistemaCrossfit.Request;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IStudentPointsRepository
    {
        Task<List<StudentPoints>> GetAll();
		Task<List<StudentPoints>> GetStudentPointsByIdStudent(int idStudent);
		Task<int> GetTotalStudentPointsByIdStudent(int idStudent);
        Task<StudentPoints> GetByIds(int idStudent, int idExercise);
        Task<StudentPoints> Create(StudentPointsRequest requestBody);
        Task<StudentPoints> Update(StudentPointsRequest requestBody, int idStudent, int idExercise);
        Task<Boolean> Delete(int idStudent, int idExercise);
	}
}
