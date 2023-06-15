using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCrossfit.Models
{
	public class PaymentType : BaseModel
	{
		[Key]
		[Column("id_payment_type")]
		public int IdPaymentType { get; set; }
		public string Name { get; set; } = null!;
	}
}
