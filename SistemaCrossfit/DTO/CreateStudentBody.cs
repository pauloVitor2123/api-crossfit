using SistemaCrossfit.Models;

namespace SistemaCrossfit.DTO
{
    public class CreateStudentBody : BaseModel
    {
        public CreateStudentBody() { }
        public CreateStudentBody(User user, Student student)
        {
            Email = user.Email;
            Password = user.Password;
            Name = user.Name;
            SocialName = user.SocialName;
            IdStudent = student.IdStudent;
            IdAddress = student.IdAddress;
            IdGender = student.IdGender;
            BirthDate = student.BirthDate;
            IsBlocked = student.IsBlocked;
            BlockDescription = student.BlockDescription;
            CreatedAt = user.CreatedAt;
            UpdatedAt = user.UpdatedAt;
            DeletedAt = user.DeletedAt;
        }
        /*-------- Student Props ----------*/
        public int? IdStudent { get; set; }
        public int? IdAddress { get; set; }
        public int IdGender { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? IsBlocked { get; set; }
        public string? BlockDescription { get; set; }

        /*-------- User Props ----------*/
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? SocialName { get; set; }
    }
}