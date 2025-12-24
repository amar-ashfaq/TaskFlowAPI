using System.ComponentModel.DataAnnotations;

namespace TaskFlowAPI.DTOs
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string HashedPassword { get; set; }
        [Required]
        public string PasswordSalt { get; set; }
    }
}
