using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class GenreMap : BaseMap<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.IdGenre);
            builder.Property(x => x.IdGenre).HasColumnName("id_genre").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnName("name");
            builder.Property(x => x.NormalizedName).IsRequired().HasMaxLength(255).HasColumnName("normalized_name");
            builder.Property(x => x.Active).IsRequired().HasColumnName("active").HasDefaultValue(true);

            base.Configure(builder);
        }
    }
}
