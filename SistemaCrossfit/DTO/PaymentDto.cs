using SistemaCrossfit.Models;

namespace SistemaCrossfit.DTO
{
    public class PaymentDto
    {
        public int IdPayment { get; set; }
        public Student Student { get; set; }
        public Status Status { get; set; }
        public PaymentType? PaymentType { get; set; }
        public DateTime DueDate { get; set; }
        public double? Invoice { get; set; }
        public DateTime? DatePayment { get; set; }
    }
}
