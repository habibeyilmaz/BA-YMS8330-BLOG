using Blog.Data.Abstraction;

namespace Blog.Data.Models
{
    public class Nationality : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}