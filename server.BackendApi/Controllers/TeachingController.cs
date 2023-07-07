using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Bills;
using server.Application.Catalog.Teachings;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.Teaching;

namespace server.BackendApi.Controllers
{
    [Route("api/teachings")]
    [ApiController]
    public class TeachingController : ControllerBase
    {
        public readonly ITeachingService _teachingService;
        public readonly LangDbContext _context;


        public TeachingController(ITeachingService teachingService, LangDbContext context)
        {
            _teachingService = teachingService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TeachingCreateRequest data)
        {
            try
            {
                var teaching = await _teachingService.Create(data);
                if (teaching is Teaching)
                {
                    return StatusCode(200,teaching);
                }
                else
                {
                    return StatusCode(500, teaching);
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
                var teachings = await _teachingService.FindAll();
                return StatusCode(200, teachings);

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
                var bill = await _teachingService.FindOne(new Guid(id));

                return StatusCode(200, bill);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] TeachingUpdateRequest request)
        {
            try
            {
                var isSucess = await _teachingService.Update(new Guid(id), request);
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Teaching was updated successfully." });

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
                var isSucess = await _teachingService.Remove(new Guid(id));
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Teaching was removed successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
