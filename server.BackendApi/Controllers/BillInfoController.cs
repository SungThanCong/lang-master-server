using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Bills;
using server.Application.Catalog.TimeFrames;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.TimeFrame;

namespace server.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillInfoController : ControllerBase
    {
        public readonly IBillInfoService _billInfoService;
        public readonly LangDbContext _context;


        public BillInfoController(IBillInfoService billInfoService, LangDbContext context)
        {
            _billInfoService = billInfoService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] BillInfoCreateRequest data)
        {
            try
            {
                var billInfo = await _billInfoService.Create(data);
                if (billInfo is BillInfo)
                {
                    return StatusCode(200, new JsonResult(billInfo));
                }
                else
                {
                    return StatusCode(500, billInfo);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FindAll(string id)
        {
            try
            {
                var billInfos = await _billInfoService.FindAll(new Guid(id));
                return StatusCode(200, new JsonResult(billInfos));

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet("{idBill}/{idCourse}")]
        public async Task<ActionResult> FindOne(string idBill, string idCourse)
        {
            try
            {
                var billInfo = await _billInfoService.FindOne(new Guid(idBill), new Guid(idCourse));

                return StatusCode(200, new JsonResult(billInfo));

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{idBill}/{idCourse}")]
        public async Task<ActionResult> Update(string idBill, string idCourse,[FromForm] BillInfoUpdateRequest request)
        {
            try
            {
                var isSuccess = await _billInfoService.Update(new Guid(idBill), new Guid(idCourse), request);
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Bill info was updated successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{idBill}/{idCourse}")]
        public async Task<ActionResult> Remove(string idBill, string idCourse)
        {
            try
            {
                var isSuccess = await _billInfoService.Remove(new Guid(idBill), new Guid(idCourse));
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Timeframe was removed successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
