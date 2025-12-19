using System.ComponentModel.DataAnnotations;

namespace TaskFlowAPI.DTOs
{
    public class UserUpdateDto
    {
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
