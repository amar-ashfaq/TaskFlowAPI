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

        public List<TaskReadDto> GetTaskFlows(int callerUserId, bool isAdmin)
        {
            var userTaskFlows = new List<TaskFlow>();

            if (isAdmin)
            {
                userTaskFlows = _taskFlowRepository.GetTaskFlows();
            }
            else
            {
                userTaskFlows = _taskFlowRepository.GetTaskFlowsByUserId(callerUserId);
            }

            return userTaskFlows.Select(taskReadDto =>
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
        }

        public TaskReadDto GetTaskFlow(int id, int callerUserId, bool isAdmin)
        {
            var taskFlow = _taskFlowRepository.GetTaskFlow(id);

            if (!isAdmin && taskFlow.UserId != callerUserId)
            {
                throw new UnauthorizedAccessException("Cannot access tasks that don't belong to you.");
            }

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

        public TaskReadDto CreateTaskFlow(TaskCreateDto flowDto)
        {
            ArgumentNullException.ThrowIfNull(flowDto);

            var taskFlow = new TaskFlow
            {
                UserId = flowDto.UserId,
                Name = flowDto.Name,
                Description = flowDto.Description,
                Status = flowDto.Status,
                CreatedAt = flowDto.CreatedAt
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
            taskFlow.UpdatedAt = flowDto.UpdatedAt;

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
