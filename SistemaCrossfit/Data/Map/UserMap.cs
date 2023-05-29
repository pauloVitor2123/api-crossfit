using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public abstract class UserMap<TEntityUser> : BaseMap<TEntityUser> where TEntityUser : User
    {
        public override void Configure(EntityTypeBuilder<TEntityUser> builder)
        {
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
            builder.HasOne(x => x.Profile)
            .WithMany()
            .HasForeignKey(x => x.IdProfile);
        }
    }
}
