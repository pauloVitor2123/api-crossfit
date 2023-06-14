namespace SistemaCrossfit.Extensions
{
    public static class FormFileExtensions
    {
        public static string ToBase64String(this IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();
                string base64String = System.Convert.ToBase64String(fileBytes);
                return base64String;
            }
        }
    }
}
