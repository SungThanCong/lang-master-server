using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Bills;
using server.Application.Catalog.Lecturers;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.Lecturer;

namespace server.BackendApi.Controllers
{
    [Route("api/lecturers")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        public readonly ILecturerService _lecturerService;
        public readonly LangDbContext _context;


        public LecturerController(ILecturerService lecturerService, LangDbContext context)
        {
            _lecturerService = lecturerService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] LecturerCreateRequest data)
        {
            try
            {
                var lecturer = await _lecturerService.Create(data);
                if (lecturer is Lecturer)
                {
                    return StatusCode(200, new JsonResult(lecturer));
                }
                else
                {
                    return StatusCode(500, lecturer);
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
                var lecturers = await _lecturerService.FindAll();
                return StatusCode(200, new JsonResult(lecturers));

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
                var lecturer = await _lecturerService.FindOne(new Guid(id));

                return StatusCode(200, new JsonResult(lecturer));

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromForm] LecturerUpdateRequest request)
        {
            try
            {
                var isSuccess = await _lecturerService.Update(new Guid(id), request);
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Lecturer was updated successfully." });

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
                var isSucess = await _lecturerService.Remove(new Guid(id));
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Lecturer was removed successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
