using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Data.EF;
using server.ViewModel.Catalog.Report;

namespace server.BackendApi.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly LangDbContext _context;
        public ReportController(LangDbContext context)
        {
            _context = context;
        }

        [HttpPost("revenue")]
        public async Task<ActionResult> GetFromTo([FromBody] RevenueRequest request)
        {
            var from = request.From;
            var to = request.To;

            if (from == null || to == null)
                return BadRequest(new { message = "Body is empty!" });
          
            try
            {
                var result = _context.Bills
                .Where(b => b.CreatedDate >= DateTime.Parse(from) && b.CreatedDate <= DateTime.Parse(to) && !b.IsDeleted)
                .GroupBy(b => b.CreatedDate)
                .Select(g => new { Date = g.Key, Total = g.Sum(b => b.TotalFee) })
                .OrderBy(g => g.Date)
                .ToList();

                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("class")]
        public async Task<ActionResult> GetTopClasses([FromBody]ReportClassRequest request)
        {
            var month = request.Month;
            if (month == null)
                return BadRequest(new { message = "Body is empty!" });
            try
            {
                var result = _context.BillInfos
                    .Join(_context.Bills, bi => bi.IdBill, b => b.IdBill, (bi, b) => new { BillInfo = bi, Bill = b })
                    .Join(_context.Classes, b => b.BillInfo.IdClass, c => c.IdClass, (b, c) => new { BillInfo = b.BillInfo, Bill = b.Bill, Class = c })
                    .Where(b => b.Bill.CreatedDate.Month == int.Parse(month) && !b.Bill.IsDeleted)
                    .GroupBy(b => b.Class.IdClass)
                    .Select(g => new { IdClass = g.Key, ClassName = g.First().Class.ClassName, Total = g.Sum(b => b.BillInfo.Fee) })
                    .OrderByDescending(g => g.Total)
                    .Take(10)
                    .ToList();

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
