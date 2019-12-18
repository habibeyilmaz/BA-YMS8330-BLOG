using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Dto;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Demo([FromBody] DemoDto demo)
        {
            return View(demo);
        }

        public IActionResult Name([FromBody] DemoDto name)
        {
            return View(name);
        }
    }
}