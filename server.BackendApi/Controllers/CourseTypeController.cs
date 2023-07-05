using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Bills;
using server.Application.Catalog.Courses;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.Course;

namespace server.BackendApi.Controllers
{
    [Route("api/coursetypes")]
    [ApiController]
    public class CourseTypeController : ControllerBase
    {

        public readonly ICourseTypeService _courseTypeService;
        public readonly LangDbContext _context;


        public CourseTypeController(ICourseTypeService courseTypeService, LangDbContext context)
        {
            _courseTypeService = courseTypeService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] CourseTypeCreateRequest data)
        {
            try
            {
                var courseType = await _courseTypeService.Create(data);
                if (courseType is CourseType)
                {
                    return StatusCode(200, new JsonResult(courseType));
                }
                else
                {
                    return StatusCode(500, courseType);
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
                var courseTypes = await _courseTypeService.FindAll();
                return StatusCode(200, new JsonResult(courseTypes));

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
                var courseType = await _courseTypeService.FindOne(id);

                return StatusCode(200, new JsonResult(courseType));

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromForm] CourseTypeUpdateRequest request)
        {
            try
            {
                var isSuccess = await _courseTypeService.Update(id, request);
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Course type was updated successfully." });

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
                var isSuccess = await _courseTypeService.Remove(id);
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Course type was removed successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
