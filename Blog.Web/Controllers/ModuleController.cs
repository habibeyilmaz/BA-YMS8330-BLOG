using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Controllers
{
    public class ModuleController : Controller
    {
        private BlogContext _blogContext;

        public ModuleController(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        public IActionResult Categories()
        {
            var categories = _blogContext.Categories
                .Include(a => a.Blogs).OrderBy(a => a.Name).ToList();
            return View(categories);

        }
    }
}