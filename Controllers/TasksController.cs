using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Data;
using TaskFlow.DTOs;
using TaskFlow.Models;

namespace TaskFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<TasksController> _logger;

        public TasksController(AppDbContext db, ILogger<TasksController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool? isCompleted)
        {
            var q = _db.Tasks.AsQueryable();
            if (isCompleted.HasValue)
                q = q.Where(t => t.IsCompleted == isCompleted.Value);

            var list = await q.OrderByDescending(t => t.CreatedAt).ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
            };
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, TaskUpdateDto dto)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            if (!string.IsNullOrWhiteSpace(dto.Title)) task.Title = dto.Title;
            if (dto.Description != null) task.Description = dto.Description;
            if (dto.DueDate.HasValue) task.DueDate = dto.DueDate;
            if (dto.IsCompleted.HasValue && dto.IsCompleted.Value && !task.IsCompleted)
            {
                task.IsCompleted = true;
                task.CompletedAt = DateTime.UtcNow;
            }
            else if (dto.IsCompleted.HasValue && !dto.IsCompleted.Value)
            {
                task.IsCompleted = false;
                task.CompletedAt = null;
            }

            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task == null) return NotFound();
            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
