using Image.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image.Controllers
{
    public class ImageForm : Controller
    {
        private readonly IManageImage manage;
        public ImageForm(IManageImage manage)
        {
            this.manage = manage;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Index(IFormFile file)
        {
           var Result = await manage.SaveImage(file);
            if (Result == true)
            {
                ViewData["Alert"] = "Image Saved........";
                return View();
            }
            else
            {
                ViewData["Alert"] = "Error!!!!!!";
                return View();
            }
        }
    }
}
