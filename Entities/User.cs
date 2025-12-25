using System.ComponentModel.DataAnnotations;

namespace TaskFlowAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string HashedPassword { get; set; }
        [Required]
        public string PasswordSalt { get; set; }
        [Required]
        public UserRole Role { get; set; } = UserRole.User;

        public List<TaskFlow> TaskFlows { get; set; } = [];
    }
}
