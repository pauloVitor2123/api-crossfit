using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class ProfessorMap : BaseMap<Professor>
    {
        public override void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(x => x.IdProfessor);
            builder.Property(x => x.IdProfessor)
                .HasColumnName("id_professor")
                .ValueGeneratedOnAdd();
            builder.Property(x => x.IdUser)
                .IsRequired()
                .HasColumnName("id_user");

            // relationship 1 to One - One to 1
            builder.HasOne(x => x.User).WithOne(x => x.Professor).HasForeignKey<Professor>(x => x.IdUser);

            base.Configure(builder);
        }
    }
}
