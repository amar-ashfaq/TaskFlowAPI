using Microsoft.EntityFrameworkCore;
using TaskFlowAPI.Data;
using TaskFlowAPI.Entities;

namespace TaskFlowAPI.Repositories
{
    public class TaskFlowRepository : ITaskFlowRepository
    {
        private readonly AppDbContext _context;

        public TaskFlowRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<TaskFlow> GetTaskFlows()
        {
            var taskFlows = _context.TaskFlows.ToList();
            return taskFlows;
        }

        public TaskFlow GetTaskFlow(int id)
        {
            var taskFlow = _context.TaskFlows.SingleOrDefault(t => t.Id == id);

            if (taskFlow == null) 
            {
                throw new KeyNotFoundException($"Task with id {id} could not be found.");
            }

            return taskFlow;
        }

        public TaskFlow CreateTaskFlow(TaskFlow flow)
        {
            _context.TaskFlows.Add(flow);
            _context.SaveChanges();

            return flow;
        }

        public void UpdateTaskFlow()
        {
            _context.SaveChanges();
        }

        public void DeleteTaskFlow(int id)
        {
            var taskFlow = GetTaskFlow(id);

            _context.Remove(taskFlow);
            _context.SaveChanges();
        }
    }
}
