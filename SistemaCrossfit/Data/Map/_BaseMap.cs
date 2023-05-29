using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public abstract class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseModel
    {

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnOrder(int.MaxValue - 1);

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnOrder(int.MaxValue - 2);

            builder.Property(x => x.DeletedAt)
                .HasColumnName("deleted_at")
                .ValueGeneratedNever()
                .HasColumnOrder(int.MaxValue);
            builder.HasQueryFilter(x => x.DeletedAt == null);
        }
    }
}
