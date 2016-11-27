using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SurgiNeer.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult A120()
        {
            return View();
        }

        public IActionResult M120()
        {
            return View();
        }

        public IActionResult B90()
        {
            return View();
        }

        public IActionResult C60()
        {
            return View();
        }

        public IActionResult SurgiView()
        {
            return View();
        }
    }
}