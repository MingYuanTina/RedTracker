using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurgiNeer.Data;
using SurgiNeer.Models;

namespace SurgiNeer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Applies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Apply.ToListAsync());
        }

        // GET: Applies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apply = await _context.Apply.SingleOrDefaultAsync(m => m.ID == id);
            if (apply == null)
            {
                return NotFound();
            }

            return View(apply);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}
