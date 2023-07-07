using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Bills;
using server.Application.Catalog.Courses;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.Course;
using System.Data;

namespace server.BackendApi.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public readonly ICourseService _courseService;
        public readonly LangDbContext _context;


        public CourseController(ICourseService courseService, LangDbContext context)
        {
            _courseService = courseService;
            _context = context;
        }

        [HttpPost]
        [Authorize(Roles = "admin, employee")]
        public async Task<ActionResult> Create([FromBody] CourseCreateRequest data)
        {
            try
            {
                var course = await _courseService.Create(data);
                if (course is Course)
                {
                    return StatusCode(200, course);
                }
                else
                {
                    return StatusCode(500, course);
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
                var courses = await _courseService.FindAll();
                return StatusCode(200, courses);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> FindOne(Guid id)
        {
            try
            {
                var bill = await _courseService.FindOne(id);

                return StatusCode(200,bill);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "admin, employee")]
        public async Task<ActionResult> Update(string id, [FromBody] CourseUpdateRequest request)
        {
            try
            {
                var isSucess = await _courseService.Update(new Guid(id), request);
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Course was updated successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin, employee")]
        public async Task<ActionResult> Remove(string id)
        {
            try
            {
                var isSucess = await _courseService.Remove(new Guid(id));
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Course was removed successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
