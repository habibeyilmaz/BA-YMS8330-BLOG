﻿using Blog.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Data.Models
{
    public class Blog : Entity
    {
        public int UserId { get; set; }


        public User User { get; set; }

        [MinLength(1)]
        [MaxLength(250)]
        [Required]
        public string Title { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string Content { get; set;}

       
        public int Hit { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
