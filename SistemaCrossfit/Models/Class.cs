using System.ComponentModel.DataAnnotations;

namespace SistemaCrossfit.Models
{
    public class Class : BaseModel
    {
        [Key]
        public int IdClass { get; set; }
        public int IdStatus { get; set; }
        public int IdProfessor { get; set; }
        public string Name { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
        public string Description { get; set; }
        public Professor Professor { get; set; }
    }
}