using System.ComponentModel.DataAnnotations;

namespace TaskFlowAPI.DTOs
{
    public class TaskUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public TaskStatus Status { get; set; }
    }
}
