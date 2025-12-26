using TaskFlowAPI.DTOs;

namespace TaskFlowAPI.Services
{
    public interface ITaskFlowService
    {
        List<TaskReadDto> GetTaskFlows(int callerUserId, bool isAdmin);

        TaskReadDto GetTaskFlow(int id, int callerUserId, bool isAdmin);

        TaskReadDto CreateTaskFlow(TaskCreateDto flow);

        TaskReadDto UpdateTaskFlow(int id, TaskUpdateDto flow);

        void DeleteTaskFlow(int id);
    }
}
