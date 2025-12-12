using TaskFlowAPI.DTOs;
using TaskFlowAPI.Entities;
using TaskFlowAPI.Repositories;

namespace TaskFlowAPI.Services
{
    public class TaskFlowService : ITaskFlowService
    {
        private readonly ITaskFlowRepository _taskFlowRepository;

        public TaskFlowService(ITaskFlowRepository taskFlowRepository)
        {
            _taskFlowRepository = taskFlowRepository;
        }

        public List<TaskReadDto> GetTaskFlows()
        {
            var taskFlows = _taskFlowRepository.GetTaskFlows().
                Select(taskReadDto =>
                    new TaskReadDto
                    {
                        Id = taskReadDto.Id,
                        UserId = taskReadDto.UserId,
                        Name = taskReadDto.Name,
                        Description = taskReadDto.Description,
                        Status = taskReadDto.Status,
                        CreatedAt = taskReadDto.CreatedAt,
                        UpdatedAt = taskReadDto.UpdatedAt
                    }
                )
                .ToList();

            return taskFlows;
        }

        public TaskReadDto GetTaskFlow(int id)
        {
            var taskFlowDto = _taskFlowRepository.GetTaskFlow(id);

            return new TaskReadDto
            {
                Id = taskFlowDto.Id,
                UserId = taskFlowDto.UserId,
                Name = taskFlowDto.Name,
                Description = taskFlowDto.Description,
                Status = taskFlowDto.Status,
                CreatedAt = taskFlowDto.CreatedAt,
                UpdatedAt = taskFlowDto.UpdatedAt
            };
        }

        public TaskReadDto CreateTaskFlow(TaskCreateDto flowDto)
        {
            ArgumentNullException.ThrowIfNull(flowDto);

            var taskFlow = new TaskFlow
            {
                Name = flowDto.Name,
                Description = flowDto.Description,
                Status = flowDto.Status
            };

            _taskFlowRepository.CreateTaskFlow(taskFlow);

            return new TaskReadDto
            {
                Id = taskFlow.Id,
                UserId = taskFlow.UserId,
                Name = taskFlow.Name,
                Description = taskFlow.Description,
                Status = taskFlow.Status,
                CreatedAt = taskFlow.CreatedAt,
                UpdatedAt = taskFlow.UpdatedAt
            };
        }

        public TaskReadDto UpdateTaskFlow(int id, TaskUpdateDto flowDto)
        {
            ArgumentNullException.ThrowIfNull(flowDto);

            var taskFlow = _taskFlowRepository.GetTaskFlow(id);
            
            taskFlow.Name = flowDto.Name;
            taskFlow.Description = flowDto.Description;
            taskFlow.Status = flowDto.Status;

            _taskFlowRepository.UpdateTaskFlow();

            return new TaskReadDto
            {
                Id = taskFlow.Id,
                UserId = taskFlow.UserId,
                Name = taskFlow.Name,
                Description = taskFlow.Description,
                Status = taskFlow.Status,
                CreatedAt = taskFlow.CreatedAt,
                UpdatedAt = taskFlow.UpdatedAt
            };
        }

        public void DeleteTaskFlow(int id)
        {
            _taskFlowRepository.DeleteTaskFlow(id);
        }
    }
}
