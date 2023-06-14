using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaCrossfit.Models
{
    public class Status : BaseModel
    {
        [Key]
        [Column("id_status")]
        public int IdStatus { get; set; }
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public bool Active { get; set; }
    }
}
