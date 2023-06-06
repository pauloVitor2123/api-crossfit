using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class UserMap<TEntityUser> : BaseMap<TEntityUser> where TEntityUser : User
    {
        public override void Configure(EntityTypeBuilder<TEntityUser> builder)
        {
            builder.HasKey(x => x.IdUser);
            builder.Property(x => x.IdUser)
                .HasColumnName("id_user")
                .ValueGeneratedOnAdd();
            builder.Property(x => x.IdProfile)
                .IsRequired()
                .HasColumnName("id_profile");
            builder.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");
            builder.Property(x => x.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password");
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");
            builder.Property(x => x.SocialName)
                .HasMaxLength(255)
                .HasColumnName("social_name");


            // relationship 1 to Many - Many to 1
            builder.HasOne(x => x.Profile)
            .WithMany()
            .HasForeignKey(x => x.IdProfile)
            .IsRequired();
            // relationship 1 to One - One to 1
            builder.HasOne(x => x.Student).WithOne().HasForeignKey<User>(x => x.Student).IsRequired(false);
            // relationship 1 to One - One to 1
            builder.HasOne(x => x.Admin).WithOne().HasForeignKey<User>(x => x.Admin).IsRequired(false);
            // relationship 1 to One - One to 1
            builder.HasOne(x => x.Professor).WithOne().HasForeignKey<User>(x => x.Professor).IsRequired(false);


            base.Configure(builder);
        }
    }
}
