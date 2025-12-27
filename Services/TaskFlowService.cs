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
            string message = "Cannot access tasks that don't belong to you.";
            var taskFlow = _taskFlowRepository.GetTaskFlow(id);

            CheckUserAuthorisation(callerUserId, isAdmin, message, taskFlow);

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
                CreatedAt = DateTime.UtcNow
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

        public void UpdateTaskFlow(int id, TaskUpdateDto flowDto, int userCallerId, bool isAdmin)
        {
            ArgumentNullException.ThrowIfNull(flowDto);

            string message = "Cannot update a task that doesn't belong to you.";

            var taskFlow = _taskFlowRepository.GetTaskFlow(id);

            CheckUserAuthorisation(userCallerId, isAdmin, message, taskFlow);

            taskFlow.Name = flowDto.Name;
            taskFlow.Description = flowDto.Description;
            taskFlow.Status = flowDto.Status;
            taskFlow.UpdatedAt = DateTime.UtcNow;

            _taskFlowRepository.UpdateTaskFlow();
        }

        public void DeleteTaskFlow(int id, int callerUserId, bool isAdmin)
        {
            string message = "Cannot delete a task that doesn't belong to you.";
            var taskFlow = _taskFlowRepository.GetTaskFlow(id);

            CheckUserAuthorisation(callerUserId, isAdmin, message, taskFlow);

            _taskFlowRepository.DeleteTaskFlow(id);
        }

        private static void CheckUserAuthorisation(int callerUserId, bool isAdmin, string message, TaskFlow? taskFlow)
        {
            if (!isAdmin && taskFlow.UserId != callerUserId)
            {
                throw new UnauthorizedAccessException(message);
            }
        }
    }
}
