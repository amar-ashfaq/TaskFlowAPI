using TaskFlowAPI.DTOs;

namespace TaskFlowAPI.Services
{
    public interface ITaskFlowService
    {
        List<TaskReadDto> GetTaskFlows(int callerUserId, bool isAdmin);

        TaskReadDto GetTaskFlow(int id, int callerUserId, bool isAdmin);

        TaskReadDto CreateTaskFlow(TaskCreateDto flow);

        void UpdateTaskFlow(int id, TaskUpdateDto flow, int callerUserId, bool isAdmin);

        void DeleteTaskFlow(int id, int callerUserId, bool isAdmin);
    }
}
