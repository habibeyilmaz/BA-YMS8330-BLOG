using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Context;
using Blog.Data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class ContactController : Controller
    {
        
        private readonly BlogContext _blogContext;
        public ContactController(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Send([FromBody] ContactSendDto contactSend)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            _blogContext.Contacts.Add(new Data.Models.Contact()
            {
                Name = contactSend.Name,
                Surname = contactSend.Surname,
                Message = contactSend.Message,
                CreateDate = DateTime.UtcNow
            });
            _blogContext.SaveChanges();

            return new JsonResult("ok");

        
        }
    }
}