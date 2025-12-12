using System.ComponentModel.DataAnnotations;

namespace TaskFlowAPI.Entities
{
    public class TaskFlow
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
