using System.ComponentModel.DataAnnotations;

namespace SistemaCrossfit.Models
{
    public class Genre : BaseModel
    {
        [Key]
        public int IdGenre { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public bool Active { get; set; }

    }
}
