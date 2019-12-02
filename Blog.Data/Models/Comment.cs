using Blog.Data.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Models
{
    public class Comment : Entity
    {
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        [MinLength(2)]
        [MaxLength(500)]
        [Required]
        public string Content { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string Nickname { get; set; }

        [MinLength(6)]
        [MaxLength(320)]
        public string Email { get; set; }

        public int VoteUp { get; set; }
        public int VoteDown { get; set; }
    }
}