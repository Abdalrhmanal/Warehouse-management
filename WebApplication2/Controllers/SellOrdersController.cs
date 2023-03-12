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
    public class SellOrdersController : Controller
    {
        private readonly AamdbMangmentContext _context;

        public SellOrdersController(AamdbMangmentContext context)
        {
            _context = context;
        }

        // GET: SellOrders
        public async Task<IActionResult> Index()
        {
              return View(await _context.SellOrders.ToListAsync());
        }

        // GET: SellOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SellOrders == null)
            {
                return NotFound();
            }

            var sellOrder = await _context.SellOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellOrder == null)
            {
                return NotFound();
            }

            return View(sellOrder);
        }

        // GET: SellOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SellOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderDate,DiscountValue,DiscountPrecentage,BeforDiscountTotal,AfterDiscount")] SellOrder sellOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sellOrder);
        }

        // GET: SellOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SellOrders == null)
            {
                return NotFound();
            }

            var sellOrder = await _context.SellOrders.FindAsync(id);
            if (sellOrder == null)
            {
                return NotFound();
            }
            return View(sellOrder);
        }

        // POST: SellOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderDate,DiscountValue,DiscountPrecentage,BeforDiscountTotal,AfterDiscount")] SellOrder sellOrder)
        {
            if (id != sellOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellOrderExists(sellOrder.Id))
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
            return View(sellOrder);
        }

        // GET: SellOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SellOrders == null)
            {
                return NotFound();
            }

            var sellOrder = await _context.SellOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellOrder == null)
            {
                return NotFound();
            }

            return View(sellOrder);
        }

        // POST: SellOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SellOrders == null)
            {
                return Problem("Entity set 'AamdbMangmentContext.SellOrders'  is null.");
            }
            var sellOrder = await _context.SellOrders.FindAsync(id);
            if (sellOrder != null)
            {
                _context.SellOrders.Remove(sellOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellOrderExists(int id)
        {
          return _context.SellOrders.Any(e => e.Id == id);
        }
    }
}
