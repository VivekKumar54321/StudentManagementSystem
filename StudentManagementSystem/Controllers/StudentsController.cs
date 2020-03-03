using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Database;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModel;

namespace StudentManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentContext _context;

        public StudentsController(StudentContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            
                var reservation = await _context.Student.ToListAsync();
                return View(reservation);

           
            // return View(await _context.Student.ToListAsync());
        }

        //// GET: Students/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = await _context.Student
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(student);
        //}

        // GET: Students/Create
        public IActionResult Create()
        {
            var billings = _context.Billing.ToList();
            billings.Insert(0, new Billing { Id = 0, Type = "Select" });

         
            ViewBag.Billings = billings;


            var billingstype = _context.Billing.ToList();
            ViewBag.Type = billingstype.Select(X => new SelectListItem
            {

                Text = X.Type,
                Value = X.Id.ToString()

            });

          

            var billingsamount = _context.Billing.ToList();
            ViewBag.Billingsamount = billingsamount.Select(X => new SelectListItem
            {

                Text = X.Amount.ToString(),
                Value = X.Id.ToString()

            });


            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // public async Task<IActionResult> Create([Bind("Id,Name,FatherName,Gender,Address,Email,PhoneNo,DOB")] Student student)
       public async Task<IActionResult> Create(StudentViewModel studentViewModel)
        {
            //if (studentViewModel.BillingId == 0)
            //{
            //    var billings = _context.Billing.ToList();
            //    billings.Insert(0, new Billing { Id = 0, Type = "Select Billing Type" });
            //    ViewBag.Billings = billings;
            //    ModelState.AddModelError("BillingId", "Select Billing Type");
            //    return View(studentViewModel);
            //}




            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Name = studentViewModel.Name,
                    FatherName = studentViewModel.FatherName,
                    Address = studentViewModel.Address,
                    Email = studentViewModel.Email,
                   PhoneNo = studentViewModel.PhoneNo,
                    Gender = studentViewModel.Gender,
                    DOB = studentViewModel.DOB,
                    IssuedDate = studentViewModel.IssuedDate,
                    //BillingId = studentViewModel.Billing.Id,
                    //BillingType = studentViewModel.Billing.Type,
                    //BillingAmount = studentViewModel.Billing.Amount,
                


                };

                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                //_context.Add(student);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(studentViewModel);
        }

        //// GET: Students/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = await _context.Student.FindAsync(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(student);
        //}

        //// POST: Students/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FatherName,Gender,Address,Email,PhoneNo,DOB")] Student student)
        //{
        //    if (id != student.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(student);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!StudentExists(student.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(student);
        //}

        //// GET: Students/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = await _context.Student
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(student);
        //}

        //// POST: Students/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var student = await _context.Student.FindAsync(id);
        //    _context.Student.Remove(student);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool StudentExists(int id)
        //{
        //    return _context.Student.Any(e => e.Id == id);
        //}
    }
}
