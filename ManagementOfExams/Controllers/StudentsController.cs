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
    public class StudentsController : Controller
    {
        private readonly IRepository _context;

        public StudentsController(IRepository context)
        {
            _context = context;
        }

        public async Task<IActionResult> Profile( Guid id)
        {
            ViewModel profile = new ViewModel();
            var studentData= await _context.GetById<Student>(id);
            var studentGrades = await _context.GetById<Grade>(id);
            var studentSubjects = await _context.GetById<Subject>(id);
            try {
                profile.student.FirstName = studentData.FirstName;
                profile.student.LastName = studentData.LastName;
                profile.student.EmailAddress = studentData.EmailAddress;
                profile.subject.Title = studentSubjects.Title;

            }
            catch(Exception E)
            {

            }
            
            return View(profile);
        }
        
        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll<Student>());
        } 

        // GET: Students/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var student = await _context.GetById<Student>(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,UserName,Password,EmailAddress")] StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Id = Guid.NewGuid(),
                    FirstName = studentModel.FirstName,
                    LastName = studentModel.LastName,
                    UserName = studentModel.UserName,
                    EmailAddress = studentModel.EmailAddress,
                    Password = studentModel.Password

                };
                _context.Create(student);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(studentModel);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _context.GetById<Student>(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,UserName,Password,EmailAddress")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await StudentExists(student.Id)))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.GetById<Student>(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var student = await _context.GetById<Student>(id);
            _context.Delete(student);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> StudentExists(Guid id)
        {
            var student = await _context.GetById<Student>(id);
            if (student == null)
            {
                return false;
            }

            return true;
        }
    }
}
