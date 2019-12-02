using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Dto
{
    public class UserLoginDto
    {
        [Required, MinLength(6), MaxLength(345)]
        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(32)]
        public string Password { get; set; }
    }
}