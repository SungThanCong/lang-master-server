using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.TestTypes;
using server.Application.Catalog.TimeFrames;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.TestType;
using server.ViewModel.Catalog.TimeFrame;

namespace server.BackendApi.Controllers
{
    [Route("api/timeFrames")]
    [ApiController]
    public class TimeFrameController : ControllerBase
    {
        public readonly ITimeFrameService _timeFrameService;
        public readonly LangDbContext _context;


        public TimeFrameController(ITimeFrameService timeFrameService, LangDbContext context)
        {
            _timeFrameService = timeFrameService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] TimeFrameCreateRequest data)
        {
            try
            {
                var timeFrame = await _timeFrameService.Create(data);
                if (timeFrame is TimeFrame)
                {
                    return StatusCode(200, timeFrame);
                }
                else
                {
                    return StatusCode(500, timeFrame);
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
                var timeFrames = await _timeFrameService.FindAll();
                return StatusCode(200, timeFrames);

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
                var timeFrame = await _timeFrameService.FindOne(new Guid(id));

                return StatusCode(200,timeFrame);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] TimeFrameUpdateRequest request)
        {
            try
            {
                var isSuccess = await _timeFrameService.Update(new Guid(id), request);
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Timeframe was updated successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpPatch()]
        public async Task<ActionResult> UpdateAll(string id, [FromBody] List<TimeFrameUpdateRequest> request)
        {
            try
            {
                var isSuccess = await _timeFrameService.UpdateAll(request);
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Timeframes were updated successfully." });

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
                var isSuccess = await _timeFrameService.Remove(new Guid(id));
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
