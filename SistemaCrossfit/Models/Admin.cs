using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCrossfit.Models
{
    public class Admin : BaseModel
    {
        [Key]
        public int IdAdmin { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
    }
}
