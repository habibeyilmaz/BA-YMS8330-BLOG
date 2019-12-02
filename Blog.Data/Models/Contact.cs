using Blog.Data.Abstraction;

namespace Blog.Data.Models
{
    public class Contact : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Message { get; set; }
    }
}