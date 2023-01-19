using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class RegisterDtos
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phoneno { get; set; }
    }
}