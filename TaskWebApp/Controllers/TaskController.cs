using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskWebApp.Context;
using TaskWebApp.Models;
using TaskWebApp.Services.IServices;

namespace TaskWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskservice;

        public TaskController(ITaskService taskService)
        {
            _taskservice = taskService;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<List<Zadaca>>> GetAllTasks()
        {
          var tasks = await _taskservice.GetAllTasks();
            return Ok(tasks);
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zadaca>> GetTaskById(int id)
        {
          var task = await _taskservice.GetTaskById(id);
            if(task == null )
            {
                return NotFound();
            }
            return Ok(task);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Zadaca zadaca)
        {
            var updatedTask = await _taskservice.UpdateTask(id, zadaca);

            if (updatedTask == null)
            {
                return NotFound();
            }

            return Ok(updatedTask);
        }

        // POST: api/Task

        [HttpPost]
        public async Task<ActionResult<Zadaca>> CreateTask([FromBody] Zadaca zadaca)
        {
            var createdTask = await _taskservice.CreateTask(zadaca);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.TaskId }, createdTask);
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZadaca(int id)
        {
            var result = await _taskservice.DeleteTask(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
