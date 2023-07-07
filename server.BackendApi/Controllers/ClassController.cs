using Microsoft.AspNetCore.Authorization;
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
    [Route("api/classes")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        public readonly IClassService _classService;
        public readonly LangDbContext _context;


        public ClassController(IClassService classService, LangDbContext context)
        {
            _classService = classService;
            _context = context;
        }

        [Authorize(Roles ="admin")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ClassCreateRequest data)
        {
            try
            {
                
                var @class = await _classService.Create(data);
                if (@class is Class)
                {
                    return StatusCode(200,@class);
                }
                else
                {
                    return StatusCode(500, @class);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "admin, employee")]
        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            try
            {
                var classes = await _classService.FindAll();
                return StatusCode(200,classes);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "admin, employee")]
        public async Task<ActionResult> FindOne(string id)
        {
            try
            {
                var @class = await _classService.FindOne(id);

                return StatusCode(200, @class);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Update(string id, [FromBody] ClassUpdateRequest request)
        {
            try
            {
                var isSucess = await _classService.Update(id, request);
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Bill was updated successfully." });

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
                var isSucess = await _classService.Remove(id);
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Bill was removed successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
