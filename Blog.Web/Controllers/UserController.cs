using System.Linq;
using Blog.Data.Context;
using Blog.Data.Dto;
using Blog.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly BlogContext _blogContext;

        public UserController(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAction([FromBody]UserLoginDto userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid validation");
            }

            User user = _blogContext.Users.SingleOrDefault(a =>
                !a.Deleted && a.Email == userLogin.Email && a.Password == userLogin.Password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);

                return Ok(user);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        public IActionResult LogoutAction()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}