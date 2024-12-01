using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskList _iTaskList;

        public TaskListController(ITaskList iTaskList)
        {
            _iTaskList = iTaskList;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTask()
        {
            var result = await _iTaskList.GetAllTaskListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var existingTask = await _iTaskList.GetTaskListByIdAsync(id);
            if (existingTask != null)
            {
                return Ok(existingTask);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TaskList taskList)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _iTaskList.AddTaskListAsync(taskList);
            return CreatedAtAction(nameof(GetTaskById), new { id = taskList.task_id}, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskList taskList)
        {
            if(id != taskList.task_id)
            {
                return BadRequest("Task list mismatch");
            }
            try
            {
                var result = await _iTaskList.UpdateTaskListAsync(taskList);
                return Ok(result);
            }
            catch(KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _iTaskList.DeleteTaskListAsync(id);
            if(!result)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
