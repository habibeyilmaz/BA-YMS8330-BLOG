using Blog.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Models
{
    public class Contact:Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Message { get; set; }
    }
}
