using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Attendances;
using server.Application.Catalog.Bills;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Attendance;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.User;

namespace server.BackendApi.Controllers
{
    [Route("api/bills")]
    [ApiController]
    public class BillController : ControllerBase
    {
        public readonly IBillService _billService;
        public readonly LangDbContext _context;


        public BillController(IBillService billService, LangDbContext context)
        {
            _billService = billService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] BillCreateRequest data)
        {
            try
            {
                var bill = await _billService.Create(data);
                if (bill is Bill)
                {
                    return StatusCode(200, bill);
                }
                else
                {
                    return StatusCode(500, bill);
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
                var bills = await _billService.FindAll();
                return StatusCode(200,bills);

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
                var bill = await _billService.FindOne(id);

                return StatusCode(200, bill);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] BillUpdateRequest request)
        {
            try
            {
                var isSuccess = await _billService.Update(id, request);
                if (!isSuccess)
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
        public async Task<ActionResult> Remove(string id)
        {
            try
            {
                var isSuccess = await _billService.Remove(id);
                if (!isSuccess)
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
