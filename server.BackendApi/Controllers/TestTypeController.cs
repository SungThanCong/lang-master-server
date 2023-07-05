using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Teachings;
using server.Application.Catalog.TestTypes;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Teaching;
using server.ViewModel.Catalog.TestType;

namespace server.BackendApi.Controllers
{
    [Route("api/testtypes")]
    [ApiController]
    public class TestTypeController : ControllerBase
    {
        public readonly ITestTypeService _testTypeService;
        public readonly LangDbContext _context;


        public TestTypeController(ITestTypeService testTypeService, LangDbContext context)
        {
            _testTypeService = testTypeService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] TestTypeCreateRequest data)
        {
            try
            {
                var testType = await _testTypeService.Create(data);
                if (testType is TestType)
                {
                    return StatusCode(200, new JsonResult(testType));
                }
                else
                {
                    return StatusCode(500, testType);
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
                var testTypes = await _testTypeService.FindAll();
                return StatusCode(200, new JsonResult(testTypes));

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
                var testType = await _testTypeService.FindOne(new Guid(id));

                return StatusCode(200, new JsonResult(testType));

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromForm] TestTypeUpdateRequest request)
        {
            try
            {
                var isSuccess = await _testTypeService.Update(new Guid(id), request);
                if (!isSuccess)
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
                var isSucess = await _testTypeService.Remove(new Guid(id));
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
