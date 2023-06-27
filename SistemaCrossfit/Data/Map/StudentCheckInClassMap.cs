using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class StudentCheckInClassMap : IEntityTypeConfiguration<StudentCheckInClass>
    {
        public virtual void Configure(EntityTypeBuilder<StudentCheckInClass> builder)
        {
            builder.HasKey(sc => new { sc.IdStudent, sc.IdClass });

            builder.HasOne(sc => sc.Student)
                .WithMany().HasForeignKey(sc => sc.IdStudent).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(sc => sc.Class)
                .WithMany().HasForeignKey(sc => sc.IdClass).OnDelete(DeleteBehavior.Restrict);

        }
    }
}