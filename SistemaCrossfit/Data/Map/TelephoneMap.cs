using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class TelephoneMap : BaseMap<Telephone>
    {
        public override void Configure(EntityTypeBuilder<Telephone> builder)
        {
            builder.HasKey(x => x.IdTelephone);
            builder.Property(x => x.IdTelephone).HasColumnName("id_telephone").ValueGeneratedOnAdd();
            builder.Property(x => x.IdStudent).IsRequired().HasMaxLength(255).HasColumnName("id_student");
            builder.Property(x => x.Number).IsRequired().HasColumnName("number");
            base.Configure(builder);
        }
    }
}
