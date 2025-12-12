using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<TaskReadDto> GetTaskFlows()
        {
            var taskFlows = _taskFlowService.GetTaskFlows();
            return Ok(taskFlows);
        }

        [HttpGet("{id}")]
        public ActionResult<TaskReadDto> GetTaskFlow(int id)
        {
            var taskFlow = _taskFlowService.GetTaskFlow(id);
            return Ok(taskFlow);
        }

        [HttpPost]
        public IActionResult CreateTaskFlow(TaskCreateDto taskDto) 
        { 
            var created = _taskFlowService.CreateTaskFlow(taskDto);

            Console.WriteLine(created.ToString());

            return CreatedAtAction(nameof(GetTaskFlow), new { created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTaskFlow(int id, TaskUpdateDto taskDto)
        {
            _taskFlowService.UpdateTaskFlow(id, taskDto);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteTaskFlow(int id) 
        { 
            _taskFlowService.DeleteTaskFlow(id);
            return NoContent();
        }
    }
}
