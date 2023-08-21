using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.NotificationHubs;
using NotificacionesSegurosSura.Services;
using System.Threading.Tasks;

namespace NotificationSeguroSura.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionesController : ControllerBase
    {
        private readonly NotificacionesService _service;

        public NotificacionesController(NotificacionesService service)
        {
            _service = service;
        }

        [HttpGet("unread")]
        public async Task<ActionResult<Notification>> GetUnreadNotifications()
        {
            var unreadNotifications = await _service.GetUnreadNotifications();
            return Ok(unreadNotifications);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] string content)
        {
            await _service.CreateNotification(content);
            return Ok();
        }

        [HttpPatch("{id}/read")]
        public async Task<IActionResult> MarkNotificationAsRead(int id)
        {
            await _service.MarkNotificationAsRead(id);
            return Ok();
        }


    }

}
