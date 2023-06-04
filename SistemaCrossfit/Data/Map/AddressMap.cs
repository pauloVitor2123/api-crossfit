using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class AddressMap : BaseMap<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.IdAddress);
            builder.Property(x => x.IdAddress)
                .IsRequired()
                .HasColumnName("id_address").ValueGeneratedOnAdd();
            builder.Property(x => x.PostalCode)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("postal_code");
            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("country");
            builder.Property(x => x.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            builder.Property(x => x.Street)
                .HasMaxLength(255)
                .HasColumnName("street");
            builder.Property(x => x.Number).HasColumnName("number");
            builder.Property(x => x.Neighborhood).HasMaxLength(100).HasColumnName("neighborhood");
            builder.Property(x => x.Complement).HasMaxLength(100).HasColumnName("complement");

            // Configuração do relacionamento um-para-um com Student
            builder.HasOne<Student>()
                .WithOne(x => x.Address)
                .HasForeignKey<Student>(x => x.IdAddress)
                .IsRequired(false);
        }
    }
}
