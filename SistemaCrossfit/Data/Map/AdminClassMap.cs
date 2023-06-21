using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public class AdminClassMap : BaseMap<AdminClass>
    {
        public override void Configure(EntityTypeBuilder<AdminClass> builder)
        {
            builder.HasKey(ac => new { ac.IdAdmin, ac.IdClass });

            builder.HasOne(ac => ac.Admin)
                .WithMany().HasForeignKey(ac => ac.IdAdmin).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ac => ac.Class)
                .WithMany().HasForeignKey(ac => ac.IdClass).OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}