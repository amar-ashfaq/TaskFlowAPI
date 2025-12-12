using TaskFlowAPI.Entities;

namespace TaskFlowAPI.Repositories
{
    public interface ITaskFlowRepository
    {
        List<TaskFlow> GetTaskFlows();

        TaskFlow GetTaskFlow(int id);

        TaskFlow CreateTaskFlow(TaskFlow flow);

        TaskFlow UpdateTaskFlow(int id, TaskFlow flow);

        void DeleteTaskFlow(int id);
    }
}
