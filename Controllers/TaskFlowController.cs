using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskFlowAPI.DTOs;
using TaskFlowAPI.Services;

namespace TaskFlowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskFlowController : ControllerBase
    {
        private readonly ITaskFlowService _taskFlowService;

        public TaskFlowController(ITaskFlowService taskFlowService)
        {
            _taskFlowService = taskFlowService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<TaskReadDto> GetTaskFlows()
        {
            var callerUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var callerUserRole = User.IsInRole("Admin");

            var taskFlows = _taskFlowService.GetTaskFlows(callerUserId, callerUserRole);
            return Ok(taskFlows);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<TaskReadDto> GetTaskFlow(int id)
        {
            var callerUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var callerUserRole = User.IsInRole("Admin");

            var taskFlow = _taskFlowService.GetTaskFlow(id, callerUserId, callerUserRole);
            return Ok(taskFlow);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateTaskFlow(TaskCreateDto taskDto) 
        { 
            var created = _taskFlowService.CreateTaskFlow(taskDto);
            return CreatedAtAction(nameof(GetTaskFlow), new { created.Id }, created);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateTaskFlow(int id, TaskUpdateDto taskDto)
        {
            var callerUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var callerUserRole = User.IsInRole("Admin");

            _taskFlowService.UpdateTaskFlow(id, taskDto, callerUserId, callerUserRole);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteTaskFlow(int id) 
        {
            var callerUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var callerUserRole = User.IsInRole("Admin");

            _taskFlowService.DeleteTaskFlow(id, callerUserId, callerUserRole);
            return NoContent();
        }
    }
}
