using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Bills;
using server.Application.Catalog.Parameters;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.Parameter;

namespace server.BackendApi.Controllers
{
    [Route("api/parameters")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        public readonly IParameterService _parameterService;
        public readonly LangDbContext _context;


        public ParameterController(IParameterService parameterService, LangDbContext context)
        {
            _parameterService = parameterService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] ParameterCreateRequest data)
        {
            try
            {
                var parameter = await _parameterService.Create(data);
                if (parameter is Parameter)
                {
                    return StatusCode(200, new JsonResult(parameter));
                }
                else
                {
                    return StatusCode(500, parameter);
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
                var parameters = await _parameterService.FindAll();
                return StatusCode(200, new JsonResult(parameters));

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
                var parameter = await _parameterService.FindOne(new Guid(id));

                return StatusCode(200, new JsonResult(parameter));

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromForm] ParameterUpdateRequest request)
        {
            try
            {
                var isSucess = await _parameterService.Update(id, request);
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Parameter was updated successfully." });

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
                var isSucess = await _parameterService.Remove(new Guid(id));
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Parameter was removed successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
