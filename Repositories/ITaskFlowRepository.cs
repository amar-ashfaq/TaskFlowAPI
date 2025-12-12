using TaskFlowAPI.Entities;

namespace TaskFlowAPI.Repositories
{
    public interface ITaskFlowRepository
    {
        List<TaskFlow> GetTaskFlows();

        TaskFlow GetTaskFlow(int id);

        TaskFlow CreateTaskFlow(TaskFlow flow);

        void UpdateTaskFlow();

        void DeleteTaskFlow(int id);
    }
}
