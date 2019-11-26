using Blog.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Data.Models
{
    public class Page: Entity
    {
        [Required, MinLength(1), MaxLength(150)]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }

        public Enums.PageKind PageKind { get; set; }
    }
}
