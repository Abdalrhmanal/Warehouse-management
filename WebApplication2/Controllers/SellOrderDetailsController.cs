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
    public class SellOrderDetailsController : Controller
    {
        private readonly AamdbMangmentContext _context;

        public SellOrderDetailsController(AamdbMangmentContext context)
        {
            _context = context;
        }

        // GET: SellOrderDetails
        public async Task<IActionResult> Index()
        {
              return View(await _context.SellOrderDetails.ToListAsync());
        }

        // GET: SellOrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SellOrderDetails == null)
            {
                return NotFound();
            }

            var sellOrderDetail = await _context.SellOrderDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellOrderDetail == null)
            {
                return NotFound();
            }

            return View(sellOrderDetail);
        }

        // GET: SellOrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SellOrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quentite,ItemTotal,ProdectId,SorderId")] SellOrderDetail sellOrderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellOrderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sellOrderDetail);
        }

        // GET: SellOrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SellOrderDetails == null)
            {
                return NotFound();
            }

            var sellOrderDetail = await _context.SellOrderDetails.FindAsync(id);
            if (sellOrderDetail == null)
            {
                return NotFound();
            }
            return View(sellOrderDetail);
        }

        // POST: SellOrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quentite,ItemTotal,ProdectId,SorderId")] SellOrderDetail sellOrderDetail)
        {
            if (id != sellOrderDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellOrderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellOrderDetailExists(sellOrderDetail.Id))
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
            return View(sellOrderDetail);
        }

        // GET: SellOrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SellOrderDetails == null)
            {
                return NotFound();
            }

            var sellOrderDetail = await _context.SellOrderDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellOrderDetail == null)
            {
                return NotFound();
            }

            return View(sellOrderDetail);
        }

        // POST: SellOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SellOrderDetails == null)
            {
                return Problem("Entity set 'AamdbMangmentContext.SellOrderDetails'  is null.");
            }
            var sellOrderDetail = await _context.SellOrderDetails.FindAsync(id);
            if (sellOrderDetail != null)
            {
                _context.SellOrderDetails.Remove(sellOrderDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellOrderDetailExists(int id)
        {
          return _context.SellOrderDetails.Any(e => e.Id == id);
        }
    }
}
