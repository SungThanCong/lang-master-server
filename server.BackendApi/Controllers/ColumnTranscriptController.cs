﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Bills;
using server.Application.Catalog.ColumnTranscripts;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.ColumnTranscript;
using System.Data;

namespace server.BackendApi.Controllers
{
    [Route("api/columntranscripts")]
    [ApiController]
    public class ColumnTranscriptController : ControllerBase
    {
        public readonly IColumnTranscriptService _columnTranscriptService;
        public readonly LangDbContext _context;


        public ColumnTranscriptController(IColumnTranscriptService columnTranscriptService, LangDbContext context)
        {
            _columnTranscriptService = columnTranscriptService;
            _context = context;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Create([FromBody] ColumnTranscriptCreateRequest data)
        {
            try
            {
                var columnTranscript = await _columnTranscriptService.Create(data);
                if (columnTranscript is ColumnTranscript)
                {
                    return StatusCode(200, columnTranscript);
                }
                else
                {
                    return StatusCode(500, columnTranscript);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin, employee, lecturer")]
        public async Task<ActionResult> FindAll()
        {
            try
            {
                var bills = await _columnTranscriptService.FindAll();
                return StatusCode(200, bills);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "admin, employee, lecturer")]
        public async Task<ActionResult> FindOne(string id)
        {
            try
            {
                var bill = await _columnTranscriptService.FindOne(id);

                return StatusCode(200,bill);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] ColumnTranscriptUpdateRequest request)
        {
            try
            {
                var isSucess = await _columnTranscriptService.Update(id, request);
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
        public async Task<ActionResult> Remove(string id)
        {
            try
            {
                var isSucess = await _columnTranscriptService.Remove(id);
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
