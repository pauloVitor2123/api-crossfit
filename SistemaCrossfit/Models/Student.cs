using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaCrossfit.Models
{
    public class Student : User
    {
        public int IdStudent { get; set; }
        [Column("id_genre")]
        public int IdGenre { get; set; }
        [SwaggerSchema]
        [JsonIgnore]
        public Genre? Genre { get; set; }

        [Column("id_address")]
        public int? IdAddress { get; set; }
        [SwaggerSchema]
        [JsonIgnore]
        public Address? Address { get; set; }

        [SwaggerSchema]
        public DateTime? BirthDate { get; set; }
        [SwaggerSchema]
        public bool? IsBlocked { get; set; }
        [SwaggerSchema]
        public string? BlockDescription { get; set; }
        /*public FileAttributes ImageProfile { get; set; }*/
    }
}
