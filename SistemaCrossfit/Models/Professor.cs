
using System.ComponentModel.DataAnnotations;

namespace SistemaCrossfit.Models
{
    public class Professor : BaseModel
    {
        [Key]
        public int IdProfessor { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
    }
}
