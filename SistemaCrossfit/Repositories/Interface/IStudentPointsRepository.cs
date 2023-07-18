using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;
using SistemaCrossfit.Request;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IStudentPointsRepository
    {
        Task<List<StudentPoints>> GetAll();
        Task<StudentPoints> GetById(int idStudentPoints);
        Task<List<StudentPoints>> GetListByIds(int idStudent, int idExercise);
        Task<List<StudentPointsWithExerciseNameDTO>> GetListByIdStudent(int idStudent);
        Task<List<StudentPoints>> GetListByIdExercise(int idExercise);
        Task<int> GetTotalPointsByIds(int idStudent, int idExercise);
        Task<int> GetTotalPointsByIdStudent(int idStudent);
        Task<StudentPoints> Create(StudentPointsRequest requestBody);
        Task<StudentPoints> Update(StudentPointsRequest requestBody, int idStudentPoints);
        Task<Boolean> Delete(int idStudentPoints);
    }
}
