using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data.Map;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Telephone> Telephone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new AdminMap());
            modelBuilder.ApplyConfiguration(new GenreMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new StatusMap());
            modelBuilder.ApplyConfiguration(new ExerciseMap());
            modelBuilder.ApplyConfiguration(new PaymentTypeMap());
            modelBuilder.ApplyConfiguration(new TelephoneMap());
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
