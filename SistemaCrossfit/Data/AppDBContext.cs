using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data.Map;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Profile> Profile { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new AdminMap());
            modelBuilder.ApplyConfiguration(new GenreMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;

                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entity.GetType().GetProperty("DeletedAt")?.SetValue(entity, DateTime.Now);
                }
                else if (entry.State == EntityState.Added)
                {
                    entity.GetType().GetProperty("CreatedAt")?.SetValue(entity, DateTime.Now);
                    entity.GetType().GetProperty("UpdatedAt")?.SetValue(entity, DateTime.Now);
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.GetType().GetProperty("UpdatedAt")?.SetValue(entity, DateTime.Now);
                }

            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
