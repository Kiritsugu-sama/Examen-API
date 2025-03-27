using Examen_AlvaroReyes.Controllers.TaskController.Models;
using Examen_AlvaroReyes.DB.Examen.Entities;
using Examen_AlvaroReyes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Examen_AlvaroReyes.Controllers.TaskController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasks();
            var taskParsed = tasks.Select(x => new TaskResponseDto
            {
                TaskID = x.TaskId,
                TaskName = x.TaskName,
                TaskDescription = x.TaskDescription,
                TaskActive = x.TaskActive,
                TaskCreatedAt = x.TaskCreatedAt,
                TaskUpdatedAt = x.TaskUpdatedAt
            } ).ToList();
            return Ok(taskParsed);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskRegisterDto taskDto)
        {
            try
            {
                var task = new TblTask
                {
                    TaskName = taskDto.TaskName,
                    TaskDescription = taskDto.TaskDescription
                };

                var createdTask = await _taskService.CreateTask(task);
              
                return Ok(createdTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskUpdateDto taskDto)
        {
            try
            {
                var task = new TblTask
                {
                    TaskName = taskDto.TaskName,
                    TaskDescription = taskDto.TaskDescription,
                    TaskActive = taskDto.TaskActive
                };

                var updatedTask = await _taskService.UpdateTask(id, task);
                if (updatedTask == null)
                {
                    return NotFound("Tarea no encontrada");
                }
                return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var verificacion = await _taskService.DeleteTask(id);
                if (verificacion == "")
                {
                    return NotFound("Tarea no encontrada");
                }
                return Ok(verificacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      
    }
}
