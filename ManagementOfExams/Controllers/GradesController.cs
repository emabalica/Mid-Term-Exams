using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagementOfExams.Data;
using ManagementOfExams.Models;
using ManagementOfExams.Repos;

namespace ManagementOfExams.Controllers
{
    public class GradesController : Controller
    {
        private readonly IRepository _context;

        public GradesController(IRepository context)
        {
            _context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll<Grade>());
        }


        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var grade = await _context.GetById<Grade>(id);

            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Value,Date")] GradeModel gradeModel)
        {
            if (ModelState.IsValid)
            {
                var grade = new Grade
                {
                    Id = Guid.NewGuid(),
                    Value = gradeModel.Value,
                    Date = gradeModel.Date

                };
                _context.Create(grade);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(gradeModel);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {

            var grade = await _context.GetById<Grade>(id);
            if (grade == null)
            {
                return NotFound();
            }
            return View(grade);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Value,Date")] Grade grade)
        {
            if (id != grade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grade);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await TeacherExists(grade.Id)))
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
            return View(grade);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.GetById<Grade>(id);

            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var grade = await _context.GetById<Grade>(id);
            _context.Delete(grade);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TeacherExists(Guid id)
        {
            var grade = await _context.GetById<Grade>(id);
            if (grade == null)
            {
                return false;
            }

            return true;
        }
    }
}
