using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Data.Context;
using Blog.Data.Dto;
using Blog.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog = Blog.Data.Models.Blog;

namespace Blog.Web.Controllers
{
    public class ManageController : Controller
    {
        private readonly BlogContext _blogContext;

        public ManageController(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("userId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Manage");
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginAction([FromBody]ManageLoginActionDto manageLoginActionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("kötü çocuk");
            }

            User user = _blogContext
                .Users.SingleOrDefault(a => a.Email == manageLoginActionDto.Email
                                            && a.Password == manageLoginActionDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            HttpContext.Session.SetInt32("userId", user.Id);

            return new JsonResult(user);
        }

        public IActionResult LogoutAction()
        {
            HttpContext.Session.Remove("userId");
            return RedirectToAction("Login", "Manage");
        }

        public IActionResult ManageBlog(int id)
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Login", "Manage");
            }

            Data.Models.Blog blogModel = new Data.Models.Blog();

            if (id != 0)
            {
                blogModel = _blogContext.Blogs.Find(id);
            }
            

            List<Category> categories = _blogContext.Categories.ToList();

            var resultTuple = new Tuple<int, List<Category>, Data.Models.Blog>(id, categories, null);

            return View(resultTuple);
        }

        public IActionResult ManageBlogAction([FromBody] ManageBlogActionDto manageBlogActionDto)
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("bad boy");
            }
            Data.Models.Blog blog;

            if (manageBlogActionDto.Id!= 0)
            {
                blog = _blogContext.Blogs.Find(manageBlogActionDto.Id);

                blog.Title= manageBlogActionDto.Title;
                blog.Content= manageBlogActionDto.Content;
                blog.CategoryId= manageBlogActionDto.CategoryId;
                _blogContext.Blogs.Update(blog);

            }
            else
            {
                blog = new Data.Models.Blog()
                {
                    CategoryId = manageBlogActionDto.CategoryId,
                    CreateDate = DateTime.UtcNow,
                    Content = manageBlogActionDto.Content,
                    Title = manageBlogActionDto.Title,
                    Hit = 0,
                    Deleted = false,
                    UserId = HttpContext.Session.GetInt32("userId").Value
                };
                _blogContext.Blogs.Add(blog);

            }
            _blogContext.SaveChanges();
            return new JsonResult(blog);
        }
    }
}