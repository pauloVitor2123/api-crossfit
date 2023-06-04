using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaCrossfit.Models
{
    public class Genre : BaseModel
    {
        public Genre()
        {
            this.Active = true;
        }
        [SwaggerSchema]
        public int IdGenre { get; set; }
        [JsonIgnore]
        public List<Student>? Students { get; set; }
        [SwaggerSchema]
        public string Name { get; set; }
        [SwaggerSchema]
        public string NormalizedName { get; set; }
        [SwaggerSchema]
        public bool Active { get; set; }

    }
}
