using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCrossfit.Models
{
    public class AdminClass : BaseModel
    {
        [Required]
        public int IdAdmin { get; set; }
        [Required]
        public int IdClass { get; set; }

        [ForeignKey("id_admin")]
        public Admin Admin { get; set;}
        [ForeignKey("id_class")]
        public Class Class { get; set; }
    }
}