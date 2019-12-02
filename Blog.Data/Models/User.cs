using Blog.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Data.Models
{
    public class User : Entity
    {
        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        public string Username { get; set; }
        [MinLength(2)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MinLength(2)]
        [MaxLength(50)]
        [Required]
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public Enums.Gender Gender { get; set; }
        [MinLength(6)]
        [MaxLength(320)]
        [Required]
        public string Email { get; set; }
        public int? NationalityId { get; set; }
        public Nationality Nationality { get; set; }
        [MinLength(8)]
        [MaxLength(32)]
        [Required]
        public string Password { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}