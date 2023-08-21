using Microsoft.EntityFrameworkCore;
using NotificationSegurosSura.Domain.Entities;

namespace NotificacionesSegurosSura.Persistencia.Shared
{
    public class NotificacionesDbContext : DbContext
    {
        public NotificacionesDbContext(DbContextOptions<NotificacionesDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notificaciones>().ToTable("Notificaciones");
        }

        public DbSet<Notificaciones> Notificaciones { get; set;}

    }
}
