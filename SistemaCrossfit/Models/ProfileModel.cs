

namespace SistemaCrossfit.Models
{
    public class ProfileModel : BaseModel
    {
        public int IdProfile { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public bool Active { get; set; }

    }
}
