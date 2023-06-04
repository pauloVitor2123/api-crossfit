
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaCrossfit.Models
{
    public class BaseModel
    {
        [JsonIgnore]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }
}
