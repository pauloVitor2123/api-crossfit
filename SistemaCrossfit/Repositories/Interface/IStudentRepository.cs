using SistemaCrossfit.DTO.Student;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAll();
        Task<Student> GetById(int id);
        Task<Student> Create(CreateStudent profile);
        Task<Student> Update(CreateStudent profile, int id);
        Task<Boolean> Delete(int id);
        Task<Boolean> Block(int id, string? description);
        Task<Boolean> Unblock(int id);
        Task<Student> ConnectAddressWithStudent(int idStudent, int idAddress);

    }
}
