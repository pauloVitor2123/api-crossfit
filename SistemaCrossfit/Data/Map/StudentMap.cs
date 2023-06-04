using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class StudentMap : UserMap<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.IdStudent);
            builder.Property(x => x.IdStudent)
                .HasColumnName("id_student")
                .ValueGeneratedOnAdd();
            builder.Property(x => x.IsBlocked)
                .HasDefaultValue(false)
                .HasColumnName("is_blocked");
            builder.Property(x => x.BlockDescription)
                .HasMaxLength(500)
                .HasColumnName("block_description")
                .HasDefaultValue(null);
            builder.Property(x => x.BirthDate)
                .HasColumnName("birth_date");

            // relationship 1 to 1
            builder.HasOne(x => x.Address)
               .WithOne()
               .HasForeignKey<Student>(x => x.IdAddress);

            // relationship 1 to Many
            builder.HasOne(x => x.Genre)
                .WithMany(e => e.Students)
                .HasForeignKey(e => e.IdGenre);


            base.Configure(builder);
        }
    }
}
