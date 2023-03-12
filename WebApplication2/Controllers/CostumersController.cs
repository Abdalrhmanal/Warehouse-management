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
    public class CostumersController : Controller
    {
        private readonly AamdbMangmentContext _context;

        public CostumersController(AamdbMangmentContext context)
        {
            _context = context;
        }

        // GET: Costumers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Costumers.ToListAsync());
        }

        // GET: Costumers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Costumers == null)
            {
                return NotFound();
            }

            var costumer = await _context.Costumers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costumer == null)
            {
                return NotFound();
            }

            return View(costumer);
        }

        // GET: Costumers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Costumers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,NumberPhone,CityId")] Costumer costumer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(costumer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(costumer);
        }

        // GET: Costumers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Costumers == null)
            {
                return NotFound();
            }

            var costumer = await _context.Costumers.FindAsync(id);
            if (costumer == null)
            {
                return NotFound();
            }
            return View(costumer);
        }

        // POST: Costumers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,NumberPhone,CityId")] Costumer costumer)
        {
            if (id != costumer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(costumer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostumerExists(costumer.Id))
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
            return View(costumer);
        }

        // GET: Costumers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Costumers == null)
            {
                return NotFound();
            }

            var costumer = await _context.Costumers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costumer == null)
            {
                return NotFound();
            }

            return View(costumer);
        }

        // POST: Costumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Costumers == null)
            {
                return Problem("Entity set 'AamdbMangmentContext.Costumers'  is null.");
            }
            var costumer = await _context.Costumers.FindAsync(id);
            if (costumer != null)
            {
                _context.Costumers.Remove(costumer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CostumerExists(int id)
        {
          return _context.Costumers.Any(e => e.Id == id);
        }
    }
}
