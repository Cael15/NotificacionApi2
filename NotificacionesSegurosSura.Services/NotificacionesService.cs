using Microsoft.Azure.NotificationHubs;
using NotificacionesSegurosSura.Domain.Interfaces;
using NotificationSegurosSura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificacionesSegurosSura.Services
{
    public class NotificacionesService
    {
        private readonly INotificacionesRepository _notificacionesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationHubClient _notificationHub;

        public NotificacionesService(INotificacionesRepository notificacionesRepository, 
           IUnitOfWork unitOfWork, INotificationHubClient notificationHub)

        {
            _notificacionesRepository = notificacionesRepository;
            _unitOfWork = unitOfWork;
            _notificationHub = notificationHub;
        }

        public async Task<IEnumerable<Notificaciones>> GetUnreadNotifications()
        {
            return await _notificacionesRepository.GetUnreadNotificationsAsync();
        }

        public async Task CreateNotification(string mensaje)
        {
            var newNotification = new Notificaciones
            {
                Mensaje = mensaje,
                EsLeido = false,
            };

            await _notificacionesRepository.CreateAsync(newNotification);
            await _unitOfWork.CommitAsync();
        }

        public async Task MarkNotificationAsRead(int notificacionId)
        {
            var notificacion = await _notificacionesRepository.GetByIdAsync(notificacionId);

            if (notificacion != null)
            {
                notificacion.EsLeido = true;
                await _notificacionesRepository.UpdateAsync(notificacion);
                await _unitOfWork.CommitAsync();

                await SendPushNotification(notificacion);
            }
        }

        private async Task SendPushNotification(Notificaciones notificacion)
        {
            var notificationPayload = "{\"data\":{\"message\":\"" + notificacion.Mensaje + "\"}}";

            await _notificationHub.SendFcmNativeNotificationAsync(notificationPayload);
        }
    }
}
