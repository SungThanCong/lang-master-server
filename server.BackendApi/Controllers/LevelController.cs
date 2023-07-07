using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Bills;
using server.Application.Catalog.Levels;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.Level;

namespace server.BackendApi.Controllers
{
    [Route("api/levels")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        public readonly ILevelService _levelService;
        public readonly LangDbContext _context;


        public LevelController(ILevelService levelService, LangDbContext context)
        {
            _levelService = levelService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] LevelCreateRequest data)
        {
            try
            {
                var level = await _levelService.Create(data);
                if (level is Level)
                {
                    return StatusCode(200, level);
                }
                else
                {
                    return StatusCode(500, level);
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
                var levels = await _levelService.FindAll();
                return StatusCode(200, levels);

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
                var level = await _levelService.FindOne(new Guid(id));

                return StatusCode(200, level);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] LevelUpdateRequest request)
        {
            try
            {
                var isSucess = await _levelService.Update(new Guid(id), request);
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Level was updated successfully." });

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
                var isSucess = await _levelService.Remove(new Guid(id));
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Level was removed successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    
    }
}
