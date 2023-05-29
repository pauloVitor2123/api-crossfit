
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCrossfit.Models
{
    public class BaseModel
    {
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
