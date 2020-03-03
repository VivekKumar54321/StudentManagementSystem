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
    public class RegistrationsController : Controller
    {
        private readonly StudentContext _context;

        public RegistrationsController(StudentContext context)
        {
            _context = context;
        }

        // GET: Registrations
        public async Task<IActionResult> Index()
        {

            var studentContext = await _context.Registration.Include(r => r.Billing).Include(r => r.Faculty).Include(r => r.Student).ToListAsync(); 
            return View( studentContext);
        }

        // GET: Registrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration
                .Include(r => r.Billing)
                .Include(r => r.Faculty)
                .Include(r => r.Student)
                .FirstOrDefaultAsync(m => m.RegId == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // GET: Registrations/Create
        public IActionResult Create()
        {
            ViewData["BillingId"] = new SelectList(_context.Billing, "BillingId", "Type");
            ViewData["FacultyId"] = new SelectList(_context.Faculty, "FacultyId", "Name");
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "Address");
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegId,StudentId,BillingId,FacultyId,IssuedDate")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BillingId"] = new SelectList(_context.Billing, "BillingId", "Type", registration.BillingId);
            ViewData["FacultyId"] = new SelectList(_context.Faculty, "FacultyId", "Name", registration.FacultyId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "Address", registration.StudentId);
            return View(registration);
        }

        // GET: Registrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            ViewData["BillingId"] = new SelectList(_context.Billing, "BillingId", "Type", registration.BillingId);
            ViewData["FacultyId"] = new SelectList(_context.Faculty, "FacultyId", "Name", registration.FacultyId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "Address", registration.StudentId);
            return View(registration);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegId,StudentId,BillingId,FacultyId,IssuedDate")] Registration registration)
        {
            if (id != registration.RegId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationExists(registration.RegId))
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
            ViewData["BillingId"] = new SelectList(_context.Billing, "BillingId", "Type", registration.BillingId);
            ViewData["FacultyId"] = new SelectList(_context.Faculty, "FacultyId", "Name", registration.FacultyId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "Address", registration.StudentId);
            return View(registration);
        }

        // GET: Registrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration
                .Include(r => r.Billing)
                .Include(r => r.Faculty)
                .Include(r => r.Student)
                .FirstOrDefaultAsync(m => m.RegId == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registration = await _context.Registration.FindAsync(id);
            _context.Registration.Remove(registration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationExists(int id)
        {
            return _context.Registration.Any(e => e.RegId == id);
        }
    }
}
