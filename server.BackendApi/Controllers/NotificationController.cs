using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Bills;
using server.Application.Catalog.Notifications;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.Notification;

namespace server.BackendApi.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        public readonly INotificationService _notificationService;
        public readonly LangDbContext _context;


        public NotificationController(INotificationService notificationService, LangDbContext context)
        {
            _notificationService = notificationService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] NotificationCreateRequest data)
        {
            try
            {
                var notification = await _notificationService.Create(data);
                if (notification is Notification)
                {
                    return StatusCode(200, notification);
                }
                else
                {
                    return StatusCode(500, notification);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            try
            {
                var notifications = await _notificationService.FindAll();
                return StatusCode(200,notifications);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> FindOne(string id)
        {
            try
            {
                var notification = await _notificationService.FindOne(new Guid(id));

                return StatusCode(200, notification);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] NotificationUpdateRequest request)
        {
            try
            {
                var isSuccess = await _notificationService.Update(new Guid(id), request);
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Notification was updated successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(string id)
        {
            try
            {
                var isSuccess = await _notificationService.Remove(new Guid(id));
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Notification was removed successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


    }
}
