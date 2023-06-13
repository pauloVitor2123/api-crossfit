using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
	public class PaymentTypeFactory
	{
		public static List<PaymentType> CreateSeedPaymentType()
		{
			List<PaymentType> paymentTypes = new();

			PaymentType creditCard = new()
			{
				Name = "Cartão de Crédito"
			};
			paymentTypes.Add(creditCard);

			PaymentType debitCard = new()
			{
				Name = "Cartão de Débito"
			};
			paymentTypes.Add(debitCard);

			PaymentType pix = new()
			{
				Name = "Pix"
			};
			paymentTypes.Add(pix);

			return paymentTypes;
		}
	}
}
