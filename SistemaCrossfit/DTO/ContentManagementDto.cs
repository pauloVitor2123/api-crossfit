using SistemaCrossfit.Models;

namespace SistemaCrossfit.DTO
{
    public class ContentManagementDto
    {
        public int IdContentManagement { get; set; }
        public Address Address { get; set; }

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
