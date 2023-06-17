namespace SistemaCrossfit.Request
{
    public class PaymentRequest
    {
    }
    public class CreatePaymentRequest
    {
        public int? IdAdmin { get; set; }
        public int IdStudent { get; set; }
    }
    public class UpdatePaymentRequest
    {
        public int IdPayment { get; set; }
        public int? IdAdmin { get; set; }
        public int? IdPaymentType { get; set; }
        public double? Invoice { get; set; }
        public DateTime? DatePayment { get; set; }
    }
}
