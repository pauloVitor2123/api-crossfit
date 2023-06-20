using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaCrossfit.Models
{
    public class StudentCheckInClass : BaseModel
    {
        [Required]
        public int IdStudent { get; set; }
        [Required]
        public int IdClass { get; set; }

        [ForeignKey("id_student")]
        public Student Admin { get; set; }
        [ForeignKey("id_class")]
        public Class Class { get; set; }
    }
}