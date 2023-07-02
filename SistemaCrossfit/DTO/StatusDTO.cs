using SistemaCrossfit.Models;

namespace SistemaCrossfit.DTO
{
    public class StatusDTO
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public StatusDTO(Status s)
        {
            Name = s.Name;
            if (s.NormalizedName != null)
            {
                NormalizedName = s.NormalizedName;
            }
        }
    }
}
