using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class AdminMap : BaseMap<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.IdAdmin);
            builder.Property(x => x.IdAdmin)
                .HasColumnName("id_admin")
                .ValueGeneratedOnAdd();
            builder.Property(x => x.IdUser)
                .IsRequired()
                .HasColumnName("id_user");

            // relationship 1 to One - One to 1
            builder.HasOne(x => x.User).WithOne(x => x.Admin).HasForeignKey<Admin>(x => x.IdUser);

            base.Configure(builder);
        }
    }
}
