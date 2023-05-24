using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data.Map;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<ProfileModel> Profile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfileMap());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;

                if(entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entity.GetType().GetProperty("DeletedAt")?.SetValue(entity, DateTime.Now);
                }else if(entry.State == EntityState.Added)
                {
                    entity.GetType().GetProperty("CreatedAt")?.SetValue(entity, DateTime.Now);
                    entity.GetType().GetProperty("UpdatedAt")?.SetValue(entity, DateTime.Now);
                }
                else if(entry.State == EntityState.Modified)
                {
                    entity.GetType().GetProperty("UpdatedAt")?.SetValue(entity, DateTime.Now);
                }

            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
