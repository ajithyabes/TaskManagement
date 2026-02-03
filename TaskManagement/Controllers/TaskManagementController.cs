using Microsoft.AspNetCore.Mvc;
using TaskManagement.Data.Entities.Tables;
using TaskManagement.Data.Models.Request;
using TaskManagement.Service.Interface;

namespace TaskManagement.Controllers
{
    [Route("api/TaskManagement")]
    [ApiController]
    public class TaskManagementController : ControllerBase
    {
        private readonly ITaskManagementService _taskManagementService;

        public TaskManagementController(ITaskManagementService taskManagementService)
        {
            _taskManagementService = taskManagementService;
        }

        [HttpPost("tasks")]
        public ActionResult<IEnumerable<TaskItem>> AddTask(TaskItemRequest taskItemRequest)
        {
            try
            {
                if (taskItemRequest == null)
                {
                    return BadRequest();
                }

                var result = _taskManagementService.AddTaskItem(taskItemRequest);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("tasks/{id}/{status}")]
        public ActionResult<IEnumerable<TaskItem>> UpdateTask(int id, string status)
        {
            try
            {
                var result = _taskManagementService.UpdateTaskItem(id, status);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("tasks")]
        public ActionResult<IEnumerable<List<TaskItem>>> GetAllTaskItems()
        {
            try
            {
                var taskItems = _taskManagementService.GetAllTaskItems();
                if (taskItems == null)
                {
                    return NotFound();
                }
                return Ok(taskItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("tasks/{id}")]
        public ActionResult<IEnumerable<TaskItem>> GetTaskById(int id)
        {
            try
            {
                var taskItem = _taskManagementService.GetTaskItemById(id);
                if (taskItem == null)
                {
                    return NotFound();
                }
                return Ok(taskItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
    }
}
