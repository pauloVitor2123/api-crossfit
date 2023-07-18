using SistemaCrossfit.Models;
namespace SistemaCrossfit.DTO
{
    public class StudentDTO
    {
        public int IdStudent { get; set; }
        public string Name { get; set; }
    }

    public class ClassDTO : Class
    {
        public bool? CheckIn { get; set; }
        public List<StudentDTO>? ConfirmedStudents { get; set; }
    }
}
