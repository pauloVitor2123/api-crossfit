using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
	public class PaymentTypeMap : BaseMap<PaymentType>
	{
		public override void Configure(EntityTypeBuilder<PaymentType> builder)
		{
			builder.HasKey(x => x.IdPaymentType);
			builder.Property(x => x.IdPaymentType).HasColumnName("id_payment_type").ValueGeneratedOnAdd();
			builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnName("name");
			base.Configure(builder);
		}
	}
}
