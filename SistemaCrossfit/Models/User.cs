using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
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
        [JsonIgnore]
        public Admin? Admin { get; set; }
        [JsonIgnore]
        public Student? Student { get; set; }
        [JsonIgnore]
        public Professor? Professor { get; set; }
        [JsonIgnore]
        public Profile Profile { get; set; }
    }
}
