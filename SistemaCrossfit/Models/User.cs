using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCrossfit.Models
{
    public abstract class User : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? SocialName { get; set; }

        [ForeignKey("id_profile")]
        public int IdProfile { get; set; }
        public Profile Profile { get; }

    }
}
