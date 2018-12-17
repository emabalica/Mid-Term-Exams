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
    public class ExamsController : Controller
    {
        private readonly IRepository _context;

        public ExamsController(IRepository context)
        {
            _context = context;
        }

        // GET: Exams
        public async Task<IActionResult> Index()
        {
            //var managementContext = _context.Exams.Include(e => e.Student);
            return View(await _context.GetAll<Exam>());
        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var exam = await _context.GetById<Exam>(id);

            /*var exam = await _context.Exams
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: Exams/Create
        public IActionResult Create()
        {
            //ViewData["StudentId"] = new SelectList(_context.Students, "Id", "EmailAddress");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Observations,DateStart,DateEnd,Id")] ExamModel examModel)
        {
            if (ModelState.IsValid)
            {
                var exam = new Exam
                {
                    Id = Guid.NewGuid(),
                    Title = examModel.Title,
                    Observations = examModel.Observations,
                    DateStart = examModel.DateStart,
                    DateEnd = examModel.DateEnd,
                };
                _context.Create(exam);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(examModel);
        }

        // GET: Exams/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.GetById<Exam>(id);
            if (exam == null)
            {
                return NotFound();
            }
            //ViewData["StudentId"] = new SelectList(_context.Students, "Id", "EmailAddress", exam.StudentId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Observations,DateStart,DateEnd,StudentId,Id")] Exam exam)
        {
            if (id != exam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exam);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await ExamExists(exam.Id)))
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
            //ViewData["StudentId"] = new SelectList(_context.Students, "Id", "EmailAddress", exam.StudentId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*
            var exam = await _context.Exams
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            */
            var exam = await _context.GetById<Exam>(id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var exam = await _context.GetById<Exam>(id);
            _context.Delete(exam);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ExamExists(Guid id)
        {
            var exam = await _context.GetById<Exam>(id);

            if (exam == null)
            {
                return false;
            }

            return true;
        }
    }
}
