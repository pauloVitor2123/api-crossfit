using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class StudentMap : BaseMap<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.IdStudent);
            builder.Property(x => x.IdStudent)
                .HasColumnName("id_student")
                .ValueGeneratedOnAdd();
            builder.Property(x => x.IdGenre)
                .IsRequired()
                .HasColumnName("id_genre");
            builder.Property(x => x.IdUser)
                .IsRequired()
                .HasColumnName("id_user");
            builder.Property(x => x.IdAddress)
                .IsRequired(false)
                .HasColumnName("id_address");
            builder.Property(x => x.IsBlocked)
                .HasDefaultValue(false)
                .HasColumnName("is_blocked");
            builder.Property(x => x.BlockDescription)
                .HasMaxLength(500)
                .HasColumnName("block_description")
                .HasDefaultValue(null);
            builder.Property(x => x.BirthDate)
                .HasColumnName("birth_date");

            // relationship 1 to One - One to 1
            builder.HasOne(x => x.Address)
               .WithOne()
               .HasForeignKey<Student>(x => x.IdAddress)
               .IsRequired(false);

            // relationship 1 to Many - Many to 1
            builder.HasOne(x => x.Genre).WithMany().HasForeignKey(x => x.IdGenre);

            // relationship 1 to One - One to 1
            builder.HasOne(x => x.User).WithOne(x => x.Student).HasForeignKey<Student>(x => x.IdUser);


            base.Configure(builder);
        }
    }
}
