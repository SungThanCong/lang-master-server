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
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Create([FromBody] CourseTypeCreateRequest data)
        {
            try
            {
                var courseType = await _courseTypeService.Create(data);
                if (courseType is CourseType)
                {
                    return StatusCode(200, courseType);
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
        [Authorize(Roles = "admin, employee, lecturer")]
        public async Task<ActionResult> FindAll()
        {
            try
            {
                var courseTypes = await _courseTypeService.FindAll();
                return StatusCode(200,  courseTypes);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,employee, lecturer")]
        public async Task<ActionResult> FindOne(string id)
        {
            try
            {
                var courseType = await _courseTypeService.FindOne(id);

                return StatusCode(200, courseType);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Update(string id, [FromBody] CourseTypeUpdateRequest request)
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
        [Authorize(Roles = "admin")]
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
