using SistemaCrossfit.Models;

namespace SistemaCrossfit.DTO
{

    public class StudentNonPayingDTO
    {
        public StudentNonPayingDTO() { }
        public StudentNonPayingDTO(User user, Student student, Payment payment)
        {
            Email = user.Email;
            Name = user.Name;
            SocialName = user.SocialName;
            IdStudent = student.IdStudent;
            IsBlocked = student.IsBlocked;
            BlockDescription = student.BlockDescription;
            Status = new StatusDTO(payment.Status);
            DueDate = payment.DueDate;
            DatePayment = payment.DatePayment;
            IdPayment = payment.IdPayment;
        }
        /*-------- Student Props ----------*/
        public int? IdStudent { get; set; }
        public int? IdAddress { get; set; }
        public int? IdPayment { get; set; }
        public int IdGender { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? IsBlocked { get; set; }
        public string? BlockDescription { get; set; }

        /*-------- User Props ----------*/
        public string Email { get; set; }
        public string Name { get; set; }
        public string? SocialName { get; set; }
        /*-------- Payment Props ----------*/
        public StatusDTO Status { get; set; }
        public DateTime? DatePayment { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
