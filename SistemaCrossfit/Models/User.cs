using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCrossfit.Models
{
    public class User : BaseModel
    {
        [Key]
        [Column("id_user")]
        public int IdUser { get; set; }

        [ForeignKey("id_profile")]
        [Column("id_profile")]
        public int IdProfile { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("social_name")]
        public string? SocialName { get; set; }

        /*---------------------------------*/
        public Admin? Admin { get; set; }
        public Student? Student { get; set; }
        public Professor? Professor { get; set; }
        public Profile Profile { get; set; }
    }
}
