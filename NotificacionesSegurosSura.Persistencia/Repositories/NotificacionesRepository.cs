using Microsoft.EntityFrameworkCore;
using NotificacionesSegurosSura.Domain.Interfaces;
using NotificacionesSegurosSura.Persistencia.Shared;
using NotificationSegurosSura.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourApp.Infrastructure.Repositories
{
    public class NotificacionesRepository : INotificacionesRepository
    {
        private readonly NotificacionesDbContext _context;

        public NotificacionesRepository(NotificacionesDbContext context)
        {
            _context = context;
        }

        public async Task<Notificaciones> GetByIdAsync(int id)
        {
            return await _context.Notificaciones.FindAsync(id);
        }

        public async Task<IEnumerable<Notificaciones>> GetUnreadNotificationsAsync()
        {
            return await _context.Notificaciones
                .Where(n => !n.EsLeido)
                .ToListAsync();
        }

        public async Task CreateAsync(Notificaciones notification)
        {
            _context.Notificaciones.Add(notification);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Notificaciones notification)
        {
            _context.Notificaciones.Update(notification);
            await _context.SaveChangesAsync();
        }
    }
}
