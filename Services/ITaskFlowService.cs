using TaskFlowAPI.DTOs;

namespace TaskFlowAPI.Services
{
    public interface ITaskFlowService
    {
        List<TaskReadDto> GetTaskFlows();

        TaskReadDto GetTaskFlow(int id);

        TaskReadDto CreateTaskFlow(TaskCreateDto flow);

        TaskReadDto UpdateTaskFlow(int id, TaskUpdateDto flow);

        void DeleteTaskFlow(int id);
    }
}
