using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCrossfit.Models
{
    public class AdminClass : BaseModel
    {
        [Required]
        [Column("id_admin")]
        public int IdAdmin { get; set; }
        [Required]
        [Column("id_class")]
        public int IdClass { get; set; }
        
        public Admin Admin { get; set;}
        public Class Class { get; set; }
    }
}