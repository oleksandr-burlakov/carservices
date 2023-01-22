using Carvices.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Carvices.DAL
{
    public class EFContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceAction> ServiceActions { get; set; }
        public DbSet<ServiceActionWorker> ServiceActionWorkers { get; set; }
        public DbSet<ServiceWorkDays> ServiceWorkDays { get; set; }
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(u => u.Job)
                .WithMany(j => j.Workers)
                .HasForeignKey(u => u.JobId);

            builder.Entity<Car>()
                .HasOne(c => c.Owner)
                .WithMany(u => u.Cars)
                .HasForeignKey(c => c.OwnerId);
            builder.Entity<Car>()
                .Property(c => c.Name)
                .HasMaxLength(255);

            builder.Entity<ServiceAction>()
                .HasOne(sa => sa.Service)
                .WithMany(s => s.ServiceActions)
                .HasForeignKey(sa => sa.ServiceId);

            builder.Entity<ServiceActionWorker>()
                .HasKey(k => new { k.ServiceActionId, k.WorkerId });
            builder.Entity<ServiceActionWorker>()
                .HasOne(saw => saw.Worker)
                .WithMany(u => u.ServiceActionWorkers)
                .HasForeignKey(saw => saw.WorkerId);
            builder.Entity<ServiceActionWorker>()
                .HasOne(saw => saw.ServiceAction)
                .WithMany(sa => sa.ServiceActionWorkers)
                .HasForeignKey(saw => saw.ServiceActionId);

            builder.Entity<ServiceWorkDays>()
                .HasOne(swd => swd.Service)
                .WithMany(s => s.ServiceWorkDays)
                .HasForeignKey(swd => swd.ServiceId);
        }
    }
}
