using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaCrossfit.Models
{
    public class Payment : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPayment { get; set; }

        [ForeignKey("Admin")]
        public int? IdAdmin { get; set; }
        public virtual Admin Admin { get; set; }

        [ForeignKey("Student")]
        public int IdStudent { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Status")]
        public int IdStatus { get; set; }
        public virtual Status Status { get; set; }

        [ForeignKey("PaymentType")]
        public int? IdPaymentType { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        public DateTime DueDate { get; set; }

        public double? Invoice { get; set; }

        public DateTime? DatePayment { get; set; }
    }
}
