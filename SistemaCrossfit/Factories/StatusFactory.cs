using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
    public class StatusFactory
    {
        public static List<Status> CreateSeedStatus()
        {
            List<Status> status = new List<Status>();

            Status notStarted = new Status()
            {
                Name = "Não Iniciado",
                NormalizedName = "NOT_STARTED",
                Active = true
            };
            status.Add(notStarted);

            Status inProgress = new Status()
            {
                Name = "Em Progresso",
                NormalizedName = "IN_PROGRESS",
                Active = true
            };
            status.Add(inProgress);

            Status finalized = new Status()
            {
                Name = "Finalizado",
                NormalizedName = "FINALIZED",
                Active = true
            };
            status.Add(finalized);

            Status pendent = new Status()
            {
                Name = "Pendente",
                NormalizedName = "PENDENT",
                Active = true
            };
            status.Add(pendent);

            Status paymentDone = new Status()
            {
                Name = "Pagamento Feito",
                NormalizedName = "PAYMENT_DONE",
                Active = true
            };
            status.Add(paymentDone);


            return status;
        }
    }

}
