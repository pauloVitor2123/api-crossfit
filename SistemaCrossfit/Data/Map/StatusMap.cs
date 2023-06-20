using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class StatusMap : BaseMap<Status>
    {
        public override void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(x => x.IdStatus);
            builder.Property(x => x.IdStatus).HasColumnName("id_status").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnName("name");
            builder.Property(x => x.NormalizedName).IsRequired().HasMaxLength(255).HasColumnName("normalized_name");
            builder.Property(x => x.Active).IsRequired().HasColumnName("active");
            base.Configure(builder);
        }
    }
}
