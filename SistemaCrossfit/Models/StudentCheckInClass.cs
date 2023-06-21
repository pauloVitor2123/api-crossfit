using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaCrossfit.Models
{
    public class StudentCheckInClass : BaseModel
    {
        [Required]
        [Column("id_student")]
        public int IdStudent { get; set; }
        [Required]
        [Column("id_class")]
        public int IdClass { get; set; }

        public Student Student { get; set; }
        public Class Class { get; set; }
    }
}