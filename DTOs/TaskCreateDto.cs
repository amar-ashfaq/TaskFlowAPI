using System.ComponentModel.DataAnnotations;

namespace TaskFlowAPI.DTOs
{
    public class TaskCreateDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public TaskStatus Status { get; set; } = TaskStatus.Pending;
    }
}
