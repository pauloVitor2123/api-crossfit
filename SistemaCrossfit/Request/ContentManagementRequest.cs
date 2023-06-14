namespace SistemaCrossfit.Request
{
    public class ContentManagementRequest
    {
        public int? IdContentManagement { get; set; }
        public int IdAddress { get; set; }
        public int IdAdmin { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string AboutDescription { get; set; }
        public IFormFile MainImgUrl { get; set; }
        public IFormFile LogoImgUrl { get; set; }
        public string PageTitle { get; set; }
        public bool IsMain { get; set; }
        public string Whatsapp { get; set; }
        public string Telephone { get; set; }
        public string EmailContact { get; set; }
    }
}
