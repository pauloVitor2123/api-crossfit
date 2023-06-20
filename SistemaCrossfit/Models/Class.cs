using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCrossfit.Models
{
    public class Class : BaseModel
    {
        [Key]
        public int IdClass { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
        public string Description { get; set; }
        [ForeignKey("Professor")]
        public int IdProfessor { get; set; }
        public virtual Professor Professor { get; set; }

        [ForeignKey("Status")]
        public int IdStatus { get; set; }
        public virtual Status Status { get; set; }
    }
}