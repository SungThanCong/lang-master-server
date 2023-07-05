using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Bills;
using server.Application.Catalog.Students;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.Student;

namespace server.BackendApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IStudentService _studentService;
        public readonly LangDbContext _context;


        public StudentController(IStudentService studentService, LangDbContext context)
        {
            _studentService = studentService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] StudentCreateRequest data)
        {
            try
            {
                var student = await _studentService.Create(data);
                if (student is Student)
                {
                    return StatusCode(200, new JsonResult(student));
                }
                else
                {
                    return StatusCode(500, student);
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
                var students = await _studentService.FindAll();
                return StatusCode(200, new JsonResult(students));

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
                var student = await _studentService.FindOne(new Guid(id));

                return StatusCode(200, new JsonResult(student));

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromForm] StudentUpdateRequest request)
        {
            try
            {
                var isSuccess = await _studentService.Update(new Guid(id), request);
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Student was updated successfully." });

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
                var isSuccess = await _studentService.Remove(new Guid(id));
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Student was removed successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("updateScore")]
        public async Task<ActionResult> UpdateScore([FromForm] List<Testing> testings)
        {
            try
            {
                var isSuccess = await _studentService.UpdateScore(testings);
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Update score failed" });
                }
                return StatusCode(200, new { message = "Update score succesfully" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("class/{id}")]
        public async Task<ActionResult> FindByIdClass(string id)
        {
            try
            {
                var students = await _studentService.FindByIdClass(new Guid(id));
                return StatusCode(200, students);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
