﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_year_Project.Persistence.DbContexts;
using Final_year_Project.Application.Services.Abstractions;
using Final_year_Project.Application.Models;

namespace Final_year_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryLogController : ControllerBase
    {
        private readonly IEntryLogService _entryLogService;

        public EntryLogController(IEntryLogService entryLogService)
        {
            _entryLogService = entryLogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntryLogDto>>> GetAll()
        {
            var entryLogs = await _entryLogService.GetAllAsync();
            return Ok(entryLogs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntryLogDto>> GetById(int id)
        {
            var entryLog = await _entryLogService.GetByIdAsync(id);

            if (entryLog == null)
                return NotFound();

            return Ok(entryLog);
        }

        [HttpPost]
        public async Task<ActionResult<EntryLogDto>> Create(CreateEntryLogDto createEntryLogDto)
        {
            var createdEntryLog = await _entryLogService.CreateAsync(createEntryLogDto);
            return CreatedAtAction(nameof(GetById), new { id = createdEntryLog.Id }, createdEntryLog);
        }

        [HttpDelete("{id}")]
        //[Authorize(Policy = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _entryLogService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
