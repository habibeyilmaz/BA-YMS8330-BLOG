using System;
using Blog.Data.Enums;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options): base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Blog.Data.Models.Blog> Blogs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    CreateDate = DateTime.UtcNow,
                    Deleted = false,
                    Name = "Aşk",
                    Description = "..."
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 2,
                    CreateDate = DateTime.UtcNow,
                    Deleted = false,
                    Name = "Meşk",
                    Description = "!!!"
                }
            );
            modelBuilder.Entity<Nationality>().HasData(new Nationality()
            {
                Id = 1,
                CreateDate = DateTime.UtcNow,
                Deleted = false,
                Name = "Türkiye",
                Code = "tr"
            });
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                CreateDate = DateTime.UtcNow,
                Deleted = false,
                Username = "habibi",
                Name = "habibe",
                Surname = "Yılmaz",
                Email = "habibeezgiyilmaz@gmail.com",
                Password = "12345678",
                BirthDate = new DateTime(1986, 08, 04),
                Gender = Gender.Male,
                NationalityId = 1
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}