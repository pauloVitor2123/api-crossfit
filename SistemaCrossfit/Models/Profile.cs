using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace SistemaCrossfit.Models
{
    public class Profile : BaseModel
    {
        public Profile()
        {
            this.Active = true;
        }
        [SwaggerSchema]
        public int IdProfile { get; set; }
        [SwaggerSchema]
        public string Name { get; set; }
        [SwaggerSchema]
        public string NormalizedName { get; set; }
        [SwaggerSchema]
        public bool Active { get; set; }
    }
}
