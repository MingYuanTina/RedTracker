using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurgiNeer.Data;
using SurgiNeer.Models;

namespace SurgiNeer.Controllers
{
    public class CareerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CareerController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Applies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Apply.ToListAsync());
        }

        // GET: Applies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,Gender,LastName")] Apply apply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apply);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(apply);
        }

        // GET: Applies/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Applies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,Gender,LastName")] Apply apply)
        {
            if (id != apply.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplyExists(apply.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(apply);
        }

        // GET: Applies/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Applies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apply = await _context.Apply.SingleOrDefaultAsync(m => m.ID == id);
            _context.Apply.Remove(apply);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ApplyExists(int id)
        {
            return _context.Apply.Any(e => e.ID == id);
        }
    }
}
