using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class ProfessorMap : UserMap<Professor>
    {
        public override void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(x => x.IdProfessor);
            builder.Property(x => x.IdProfessor)
                .HasColumnName("id_professor")
                .ValueGeneratedOnAdd();

            base.Configure(builder);
        }
    }
}
