using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Send([FromBody] ContactSendDto contactSend)
        {
            return new JsonResult("ok");
        }
    }
}