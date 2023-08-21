using NotificationSegurosSura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotificacionesSegurosSura.Domain.Interfaces
{
    public interface INotificacionesRepository
    {
        Task<Notificaciones> GetByIdAsync(int id);
        Task<IEnumerable<Notificaciones>> GetUnreadNotificationsAsync();
        Task CreateAsync(Notificaciones notification);
        Task UpdateAsync(Notificaciones notification);
    }
}
