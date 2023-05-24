using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
    public abstract class BaseEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseModel
    {
        
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.CreatedAt).HasColumnName("created_at");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
            builder.Property(x => x.DeletedAt).ValueGeneratedNever().HasColumnName("deleted_at");
            builder.HasQueryFilter(x => x.DeletedAt == null);
        }
    }
}
