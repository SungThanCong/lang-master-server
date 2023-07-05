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
        //public readonly IClassService _classService;
        //public readonly LangDbContext _context;


        //public ClassController(IClassService classService, LangDbContext context)
        //{
        //    _classService = classService;
        //    _context = context;
        //}

        //[HttpPost]
        //public async Task<ActionResult> Create([FromForm] ClassCreateRequest data)
        //{
        //    try
        //    {
        //        var @class = await _classService.Create(data);
        //        if (@class is Class)
        //        {
        //            return StatusCode(200, new JsonResult(@class));
        //        }
        //        else
        //        {
        //            return StatusCode(500, @class);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}

        //[HttpGet]
        //public async Task<ActionResult> FindAll()
        //{
        //    try
        //    {
        //        var classes = await _classService.FindAll();
        //        return StatusCode(200, new JsonResult(classes));

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult> FindOne(string id)
        //{
        //    try
        //    {
        //        var bill = await _classService.FindOne(id);

        //        return StatusCode(200, new JsonResult(bill));

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}

        //[HttpPatch("{id}")]
        //public async Task<ActionResult> Update(string id, [FromForm] BillUpdateRequest request)
        //{
        //    try
        //    {
        //        var isSucess = await _billService.Update(id, request);
        //        if (!isSucess)
        //        {
        //            return StatusCode(500, new { message = $"Error updating" });
        //        }
        //        return StatusCode(200, new { message = "Bill was updated successfully." });

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Remove(string id)
        //{
        //    try
        //    {
        //        var isSucess = await _billService.Remove(id);
        //        if (!isSucess)
        //        {
        //            return StatusCode(500, new { message = $"Cannot remove" });
        //        }
        //        return StatusCode(200, new { message = "Bill was removed successfully." });

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}
    }
}
