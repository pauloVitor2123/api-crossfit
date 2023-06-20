using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class ClassMap : BaseMap<Class>
    {
        public override void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(c => c.IdClass);
            builder.Property(c => c.IdClass).HasColumnName("id_class").ValueGeneratedOnAdd();
            builder.Property(c => c.IdStatus).IsRequired().HasColumnName("id_status");
            builder.Property(c => c.IdProfessor).IsRequired().HasColumnName("id_professor");
            builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(200);
            builder.Property(x => x.Date).HasColumnName("date");
            builder.Property(c => c.StartHour).HasColumnName("start_hour");
            builder.Property(c => c.EndHour).HasColumnName("end_hour");
            builder.Property(c => c.Description).HasColumnName("description").HasColumnType("text");

            builder.HasOne(c => c.Professor)
                .WithMany().HasForeignKey(c => c.IdProfessor);

            base.Configure(builder);
        }
    }
}