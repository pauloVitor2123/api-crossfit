using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaCrossfit.Models
{
    public class Student : BaseModel
    {
        [Key]
        public int IdStudent { get; set; }
        public int? IdAddress { get; set; }
        public int IdUser { get; set; }
        public int IdGender { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? IsBlocked { get; set; }
        public string? BlockDescription { get; set; }

        /*---------------------------------*/
        [JsonIgnore]
        public Gender? Gender { get; set; }
        [JsonIgnore]
        public Address? Address { get; set; }
        public User User { get; set; }
    }
}
