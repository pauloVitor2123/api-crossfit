using SistemaCrossfit.Models;

namespace SistemaCrossfit.DTO
{
    public class CreateStudentBody : BaseModel
    {
        public CreateStudentBody() { }
        public CreateStudentBody(User user, Student student)
        {
            this.Email = user.Email;
            this.Password = user.Password;
            this.Name = user.Name;
            this.SocialName = user.SocialName;
            this.IdStudent = student.IdStudent;
            this.IdAddress = student.IdAddress;
            this.IdGenre = student.IdGenre;
            this.BirthDate = student.BirthDate;
            this.IsBlocked = student.IsBlocked;
            this.BlockDescription = student.BlockDescription;
            this.CreatedAt = user.CreatedAt;
            this.UpdatedAt = user.UpdatedAt;
            this.DeletedAt = user.DeletedAt;
        }
        /*-------- Student Props ----------*/
        public int? IdStudent { get; set; }
        public int? IdAddress { get; set; }
        public int IdGenre { get; set; }
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
