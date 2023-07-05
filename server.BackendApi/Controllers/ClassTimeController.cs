using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Bills;
using server.Application.Catalog.Classes;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.Classes;

namespace server.BackendApi.Controllers
{
    [Route("api/classtimes")]
    [ApiController]
    public class ClassTimeController : ControllerBase
    {
        public readonly IClassTimeService _classTimeService;
        public readonly LangDbContext _context;


        public ClassTimeController(IClassTimeService classTimeService, LangDbContext context)
        {
            _classTimeService = classTimeService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] ClassTimeCreateRequest data)
        {
            try
            {
                var classTime = await _classTimeService.Create(data);
                if (classTime is ClassTime)
                {
                    return StatusCode(200, new JsonResult(classTime));
                }
                else
                {
                    return StatusCode(500, classTime);
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
                var classTimes = await _classTimeService.FindAll();
                return StatusCode(200, new JsonResult(classTimes));

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
                var bill = await _classTimeService.FindOne(id);

                return StatusCode(200, new JsonResult(bill));

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromForm] ClassTimeUpdateRequest request)
        {
            try
            {
                var isSuccess = await _classTimeService.Update(id, request);
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Class time was updated successfully." });

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
                var isSuccess = await _classTimeService.Remove(id);
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Class time was removed successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
