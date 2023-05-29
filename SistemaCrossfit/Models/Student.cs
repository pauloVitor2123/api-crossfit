using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCrossfit.Models
{
    public class Student : User
    {
        public int IdStudent { get; set; }

        [Column("id_genre")]
        public int IdGenre;
        public Genre? Genre { get; set; }

        public DateTime? BirthDate { get; set; }
        public bool? IsBlocked { get; set; }
        public string? BlockDescription { get; set; }
        /*public FileAttributes ImageProfile { get; set; }*/

        [Column("id_address")]
        public int IdAddress { get; set; } // Chave estrangeira

        public Address? Address { get; set; }
    }
}
