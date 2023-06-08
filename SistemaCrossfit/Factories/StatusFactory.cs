using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
    public class StatusFactory
    {
        public static List<Status> CreateSeedStatuses()
        {
            List<Status> status = new List<Status>();

            Status active = new Status()
            {
                Name = "Active",
                NormalizedName = "ACTIVE",
                Active = true
            };
            status.Add(active);

            Status pendent = new Status()
            {
                Name = "Pendent",
                NormalizedName = "PENDENT",
                Active = true
            };
            status.Add(pendent);

            Status blocked = new Status()
            {
                Name = "Blocked",
                NormalizedName = "BLOCKED",
                Active = true
            };
            status.Add(blocked);

            return status;
        }
    }

}
