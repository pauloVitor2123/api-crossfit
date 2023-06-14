using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaCrossfit.Models
{
    public class Telephone : BaseModel
    {
        [Key]
        [Column("id_telephone")]
        public int IdTelephone { get; set; }
        [ForeignKey("IdStudent")]
        public int IdStudent { get; set; }
        public int Number { get; set; }
    }
}
