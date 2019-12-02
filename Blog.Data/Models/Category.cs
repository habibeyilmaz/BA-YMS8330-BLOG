using Blog.Data.Abstraction;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Models
{
    public class Category : Entity
    {
        [MinLength(1)]
        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}