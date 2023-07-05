using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Bills;
using server.Application.Catalog.Exams;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.Exam;

namespace server.BackendApi.Controllers
{
    [Route("api/exams")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        public readonly IExamService _examService;
        public readonly LangDbContext _context;


        public ExamController(IExamService examService, LangDbContext context)
        {
            _examService = examService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] ExamCreateRequest data)
        {
            try
            {
                var exam = await _examService.Create(data);
                if (exam is Exam)
                {
                    return StatusCode(200, new JsonResult(exam));
                }
                else
                {
                    return StatusCode(500, exam);
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
                var exams = await _examService.FindAll();
                return StatusCode(200, new JsonResult(exams));

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
                var bill = await _examService.FindOne(new Guid(id));

                return StatusCode(200, new JsonResult(bill));

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromForm] ExamUpdateRequest request)
        {
            try
            {
                var isSucess = await _examService.Update(new Guid(id), request);
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Exam was updated successfully." });

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
                var isSucess = await _examService.Remove(new Guid(id));
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Exam was removed successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
