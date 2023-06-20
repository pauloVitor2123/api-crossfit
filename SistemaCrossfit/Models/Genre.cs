using System.ComponentModel.DataAnnotations;

namespace SistemaCrossfit.Models
{
    public class Gender : BaseModel
    {
        [Key]
        public int IdGender { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public bool Active { get; set; }

    }
}
