using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudApp.Models;

namespace CrudApp.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeDetails
        public async Task<IActionResult> Index()//change check
        {
            return View(await _context.EmployeeDetails.ToListAsync());
        }

        // GET: EmployeeDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetail = await _context.EmployeeDetails
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return View(employeeDetail);
        }

        // GET: EmployeeDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,EmpCode,EmpName,EmpDesignation,EmpDepartment,EmpMobileNumber,EmpEmailId,EmpSalary,EmpAddress")] EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDetail);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Saved" });
                //return RedirectToAction(nameof(Index));
            }
            //return View(employeeDetail);
            return Json(new { success = false, message = "Failed to save the data" });
        }

        // GET: EmployeeDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetail = await _context.EmployeeDetails.FindAsync(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }
            return View(employeeDetail);
        }

        // POST: EmployeeDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("EmpId,EmpCode,EmpName,EmpDesignation,EmpDepartment,EmpMobileNumber,EmpEmailId,EmpSalary,EmpAddress")] EmployeeDetail employeeDetail)
        //{
        //    if (id != employeeDetail.EmpId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(employeeDetail);
        //            await _context.SaveChangesAsync();

        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EmployeeDetailExists(employeeDetail.EmpId))
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
        //    return View(employeeDetail);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpId,EmpCode,EmpName,EmpDesignation,EmpDepartment,EmpMobileNumber,EmpEmailId,EmpSalary,EmpAddress")] EmployeeDetail employeeDetail)
        {
            if (id != employeeDetail.EmpId)
            {
                return Json(new { success = false, message = "Employee not found" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDetail);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Updated" });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDetailExists(employeeDetail.EmpId))
                    {
                        return Json(new { success = false, message = "Employee not found" });
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Json(new { success = false, message = "Model state is not valid" });
        }



        // GET: EmployeeDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetail = await _context.EmployeeDetails
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return View(employeeDetail);
        }

        // POST: EmployeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDetail = await _context.EmployeeDetails.FindAsync(id);
            if (employeeDetail != null)
            {
                _context.EmployeeDetails.Remove(employeeDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDetailExists(int id)
        {
            return _context.EmployeeDetails.Any(e => e.EmpId == id);
        }
    }
}
