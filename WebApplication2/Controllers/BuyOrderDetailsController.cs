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
    public class BuyOrderDetailsController : Controller
    {
        private readonly AamdbMangmentContext _context;

        public BuyOrderDetailsController(AamdbMangmentContext context)
        {
            _context = context;
        }

        // GET: BuyOrderDetails
        public async Task<IActionResult> Index()
        {
              return View(await _context.BuyOrderDetails.ToListAsync());
        }

        // GET: BuyOrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BuyOrderDetails == null)
            {
                return NotFound();
            }

            var buyOrderDetail = await _context.BuyOrderDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyOrderDetail == null)
            {
                return NotFound();
            }

            return View(buyOrderDetail);
        }

        // GET: BuyOrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuyOrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quentite,ItemTotal,PruductId,BorderId")] BuyOrderDetail buyOrderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyOrderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buyOrderDetail);
        }

        // GET: BuyOrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BuyOrderDetails == null)
            {
                return NotFound();
            }

            var buyOrderDetail = await _context.BuyOrderDetails.FindAsync(id);
            if (buyOrderDetail == null)
            {
                return NotFound();
            }
            return View(buyOrderDetail);
        }

        // POST: BuyOrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quentite,ItemTotal,PruductId,BorderId")] BuyOrderDetail buyOrderDetail)
        {
            if (id != buyOrderDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyOrderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyOrderDetailExists(buyOrderDetail.Id))
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
            return View(buyOrderDetail);
        }

        // GET: BuyOrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BuyOrderDetails == null)
            {
                return NotFound();
            }

            var buyOrderDetail = await _context.BuyOrderDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyOrderDetail == null)
            {
                return NotFound();
            }

            return View(buyOrderDetail);
        }

        // POST: BuyOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BuyOrderDetails == null)
            {
                return Problem("Entity set 'AamdbMangmentContext.BuyOrderDetails'  is null.");
            }
            var buyOrderDetail = await _context.BuyOrderDetails.FindAsync(id);
            if (buyOrderDetail != null)
            {
                _context.BuyOrderDetails.Remove(buyOrderDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyOrderDetailExists(int id)
        {
          return _context.BuyOrderDetails.Any(e => e.Id == id);
        }
    }
}
