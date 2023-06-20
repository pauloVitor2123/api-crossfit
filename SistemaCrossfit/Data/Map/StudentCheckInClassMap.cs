using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class StudentCheckInClassMap : BaseMap<StudentCheckInClass>
    {
        public override void Configure(EntityTypeBuilder<StudentCheckInClass> builder)
        {
            builder.HasKey(sc => new { sc.IdStudent, sc.IdClass });
            builder.Property(sc => sc.IdStudent).IsRequired().HasColumnName("id_student");
            builder.Property(sc => sc.IdClass).IsRequired().HasColumnName("id_class");

            builder.HasOne(sc => sc.Admin)
                .WithMany().HasForeignKey(sc => sc.IdStudent);
            builder.HasOne(sc => sc.Class)
                .WithMany().HasForeignKey(sc => sc.IdClass).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}