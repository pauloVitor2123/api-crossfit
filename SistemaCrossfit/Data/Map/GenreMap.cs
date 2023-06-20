using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class GenderMap : BaseMap<Gender>
    {
        public override void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(x => x.IdGender);
            builder.Property(x => x.IdGender).HasColumnName("id_gender").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnName("name");
            builder.Property(x => x.NormalizedName).IsRequired().HasMaxLength(255).HasColumnName("normalized_name");
            builder.Property(x => x.Active).IsRequired().HasColumnName("active");

            base.Configure(builder);
        }
    }
}
