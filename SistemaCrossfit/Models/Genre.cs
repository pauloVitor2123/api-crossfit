using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCrossfit.Models
{
    public class Genre : BaseModel
    {
        public int IdGenre { get; set; }

        public List<Student> Students { get; set; }

        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public bool Active { get; set; }

    }
}
