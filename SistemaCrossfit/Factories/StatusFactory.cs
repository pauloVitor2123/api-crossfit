using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
    public class StatusFactory
    {
        public static List<Status> CreateSeedStatuses()
        {
            List<Status> status = new List<Status>();

            Status notStarted = new Status()
            {
                Name = "Not Started",
                NormalizedName = "NOT_STARTED",
                Active = true
            };
            status.Add(notStarted);

            Status inProgress = new Status()
            {
                Name = "In Progress",
                NormalizedName = "IN_PROGRESS",
                Active = true
            };
            status.Add(inProgress);

            Status finalized = new Status()
            {
                Name = "Finalized",
                NormalizedName = "FINALIZED",
                Active = true
            };
            status.Add(finalized);

            Status pendent = new Status()
            {
                Name = "Pendent",
                NormalizedName = "PENDENT",
                Active = true
            };
            status.Add(pendent);

            Status paymentDone = new Status()
            {
                Name = "Payment Done",
                NormalizedName = "PAYMENT_DONE",
                Active = true
            };
            status.Add(pendent);


            return status;
        }
    }

}
