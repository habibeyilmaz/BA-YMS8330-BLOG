using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Dto
{
    public class ManageBlogActionDto
    {
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [Required, MinLength(2), MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
