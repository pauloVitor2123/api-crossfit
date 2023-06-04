using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaCrossfit.Models
{
    public abstract class User : BaseModel
    {
        [SwaggerSchema]
        public string Email { get; set; }
        [SwaggerSchema]
        public string Password { get; set; }
        [SwaggerSchema]
        public string Name { get; set; }
        [SwaggerSchema]
        public string? SocialName { get; set; }

        [ForeignKey("id_profile")]
        public int IdProfile { get; set; }
        [JsonIgnore]
        public Profile? Profile { get; }

    }
}
