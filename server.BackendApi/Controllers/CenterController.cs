using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Bills;
using server.Application.Catalog.Centers;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.Center;

namespace server.BackendApi.Controllers
{
    [Route("api/centers")]
    [ApiController]
    public class CenterController : ControllerBase
    {
        public readonly ICenterService _centerService;
        public readonly LangDbContext _context;


        public CenterController(ICenterService centerService, LangDbContext context)
        {
            _centerService = centerService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CenterCreateRequest data)
        {
            try
            {
                var center = await _centerService.Create(data);
                if (center is Center)
                {
                    return StatusCode(200, center);
                }
                else
                {
                    return StatusCode(500, center);
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
                var centers = await _centerService.FindAll();
                return StatusCode(200, centers);

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
                var center = await _centerService.FindOne(id);

                return StatusCode(200, center);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] CenterUpdateRequest request)
        {
            try
            {
                var isSucess = await _centerService.Update(id, request);
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Center was updated successfully." });

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
                var isSucess = await _centerService.Remove(id);
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Center was removed successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
