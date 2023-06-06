using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCrossfit.Models
{
    public class Address : BaseModel
    {
        [Key]
        public virtual int IdAddress { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? Number { get; set; }
        public string? Neighborhood { get; set; }
        public string? Complement { get; set; }
    }
}
