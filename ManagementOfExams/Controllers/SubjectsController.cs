using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagementOfExams.Data;
using ManagementOfExams.Repos;
using ManagementOfExams.Models;

namespace ManagementOfExams.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly IRepository _context;

        public SubjectsController(IRepository context)
        {
            _context = context;
        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll<Subject>());
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var subject = await _context.GetById<Subject>(id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,NoOfCredits")] SubjectModel subjectModel)
        {
            if (ModelState.IsValid)
            {
                var subject = new Subject
                {
                    Id = subjectModel.Id,
                    Title = subjectModel.Title,
                    NoOfCredits = subjectModel.NoOfCredits
                };
                _context.Create(subject);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(subjectModel);
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var subject = await _context.GetById<Subject>(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,NoOfCredits")] Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await TeacherExists(subject.Id)))
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
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.GetById<Subject>(id);

            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var subject = await _context.GetById<Subject>(id);
            _context.Delete(subject);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TeacherExists(Guid id)
        {
            var subject = await _context.GetById<Subject>(id);
            if (subject == null)
            {
                return false;
            }

            return true;
        }
    }
}
