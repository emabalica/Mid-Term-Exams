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
    public class TeachersController : Controller
    {
        private readonly IRepository _context;

        public TeachersController(IRepository context)
        {
            _context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll<Teacher>());
        }
        public IActionResult Profile()
        {
            return View();
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var teacher = await _context.GetById<Teacher>(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
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
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,UserName,Password,EmailAddress")] TeacherModel teacherModel)
        {
            if (ModelState.IsValid)
            {
                var teacher = new Teacher
                {
                    Id = Guid.NewGuid(),
                    FirstName = teacherModel.FirstName,
                    LastName = teacherModel.LastName,
                    UserName = teacherModel.UserName,
                    EmailAddress = teacherModel.EmailAddress,
                    Password =  teacherModel.Password

                };
                _context.Create(teacher);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(teacherModel);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {

            var teacher = await _context.GetById<Teacher>(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,UserName,Password,EmailAddress")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! (await TeacherExists(teacher.Id)))
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
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.GetById<Teacher>(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var teacher = await _context.GetById<Teacher>(id);
            _context.Delete(teacher);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TeacherExists(Guid id)
        {
            var teacher = await _context.GetById<Teacher>(id);
            if (teacher == null)
            {
                return false;
            }

            return true;
        }
    }
}
