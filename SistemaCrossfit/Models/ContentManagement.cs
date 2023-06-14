using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaCrossfit.Models
{
    public class ContentManagement: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContentManagement { get; set; }

        [ForeignKey("Address")]
        public int IdAddress { get; set; }
        public virtual Address Address { get; set; }

        [ForeignKey("Admin")]
        public int IdAdmin { get; set; }
        public virtual Admin Admin { get; set; }

        public string Titulo { get; set; }

        public string SubTitulo { get; set; }

        public string AboutDescription { get; set; }

        public string MainImgUrl { get; set; }

        public string LogoImgUrl { get; set; }

        public string PageTitle { get; set; }

        public bool IsMain { get; set; }

        public string Whatsapp { get; set; }

        public string Telephone { get; set; }

        public string EmailContact { get; set; }
    }
}
