using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<List<CreateStudentBody>> GetAll();
        Task<Student> GetById(int id);
        Task<Student> Create(Student profile);
        Task<Student> Update(Student profile, int id);
        Task<int> DeleteReturningIdUser(int id);
        Task<Boolean> Block(int id, string? description);
        Task<Boolean> Unblock(int id);
        Task<Student> ConnectAddressWithStudent(int idStudent, int idAddress);

    }
}
