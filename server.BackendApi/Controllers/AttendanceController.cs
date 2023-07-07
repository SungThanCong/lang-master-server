using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Attendances;
using server.Application.System.Auth;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Attendance;
using server.ViewModel.Catalog.User;

namespace server.BackendApi.Controllers
{
    [Route("api/attendances")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        public readonly IAttendanceService _attendanceService;
        public readonly LangDbContext _context;
        private readonly IConfiguration _configuration;



        public AttendanceController(IAttendanceService attendanceService, LangDbContext context, IConfiguration configuration)
        {
            _attendanceService = attendanceService;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AttendanceCreateRequest data)
        {
            try
            {
                var attendance = await _attendanceService.Create(data);
                if (attendance is Attendance)
                {
                    return StatusCode(200, attendance);
                }
                else
                {
                    return StatusCode(500, attendance);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new {message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            try
            {
                var attendances = await _attendanceService.FindAll();
                return StatusCode(200, attendances);

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
                var user = await _attendanceService.FindOne(new Guid(id));
     
                return StatusCode(200,user);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] AttendanceUpdateRequest request)
        {
            try
            {
                var isSucess = await _attendanceService.Update(new Guid(id), request);
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Attendance was updated successfully." });

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
                var isSucess = await _attendanceService.Remove(new Guid(id));
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Attendance was removed successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
