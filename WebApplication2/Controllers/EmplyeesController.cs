using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EmplyeesController : Controller
    {
        private readonly AamdbMangmentContext _context;

        public EmplyeesController(AamdbMangmentContext context)
        {
            _context = context;
        }

        // GET: Emplyees
        public async Task<IActionResult> Index()
        {
              return View(await _context.Emplyees.ToListAsync());
        }

        // GET: Emplyees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Emplyees == null)
            {
                return NotFound();
            }

            var emplyee = await _context.Emplyees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emplyee == null)
            {
                return NotFound();
            }

            return View(emplyee);
        }

        // GET: Emplyees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emplyees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Father,NumberPhone,BaseSalary,CityId")] Emplyee emplyee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emplyee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emplyee);
        }

        // GET: Emplyees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Emplyees == null)
            {
                return NotFound();
            }

            var emplyee = await _context.Emplyees.FindAsync(id);
            if (emplyee == null)
            {
                return NotFound();
            }
            return View(emplyee);
        }

        // POST: Emplyees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Father,NumberPhone,BaseSalary,CityId")] Emplyee emplyee)
        {
            if (id != emplyee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emplyee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmplyeeExists(emplyee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(emplyee);
        }

        // GET: Emplyees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Emplyees == null)
            {
                return NotFound();
            }

            var emplyee = await _context.Emplyees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emplyee == null)
            {
                return NotFound();
            }

            return View(emplyee);
        }

        // POST: Emplyees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Emplyees == null)
            {
                return Problem("Entity set 'AamdbMangmentContext.Emplyees'  is null.");
            }
            var emplyee = await _context.Emplyees.FindAsync(id);
            if (emplyee != null)
            {
                _context.Emplyees.Remove(emplyee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmplyeeExists(int id)
        {
          return _context.Emplyees.Any(e => e.Id == id);
        }
    }
}
