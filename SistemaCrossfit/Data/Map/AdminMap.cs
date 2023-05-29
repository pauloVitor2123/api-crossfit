using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class AdminMap : UserMap<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.IdAdmin);
            builder.Property(x => x.IdAdmin)
                .HasColumnName("id_admin")
                .ValueGeneratedOnAdd();

            base.Configure(builder);
        }
    }
}
