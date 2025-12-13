using System.ComponentModel.DataAnnotations;

namespace TaskFlowAPI.DTOs
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string HashedPassword { get; set; }
    }
}
