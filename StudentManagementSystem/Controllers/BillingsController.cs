using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Database;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class BillingsController : Controller
    {
        private readonly StudentContext _context;

        public BillingsController(StudentContext context)
        {
            _context = context;
        }

        // GET: Billings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Billing.ToListAsync());
        }

        // GET: Billings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billing = await _context.Billing
                .FirstOrDefaultAsync(m => m.BillingId == id);
            if (billing == null)
            {
                return NotFound();
            }

            return View(billing);
        }

        // GET: Billings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Billings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Date,Amount")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(billing);
        }

        // GET: Billings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billing = await _context.Billing.FindAsync(id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        // POST: Billings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Date,Amount")] Billing billing)
        {
            if (id != billing.BillingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillingExists(billing.BillingId))
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
            return View(billing);
        }

        // GET: Billings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billing = await _context.Billing
                .FirstOrDefaultAsync(m => m.BillingId == id);
            if (billing == null)
            {
                return NotFound();
            }

            return View(billing);
        }

        // POST: Billings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billing = await _context.Billing.FindAsync(id);
            _context.Billing.Remove(billing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillingExists(int id)
        {
            return _context.Billing.Any(e => e.BillingId == id);
        }
    }
}
