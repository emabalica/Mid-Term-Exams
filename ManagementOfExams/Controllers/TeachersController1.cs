using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementOfExams.Data;
using ManagementOfExams.Models;
using ManagementOfExams.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagementOfExams.Controllers
{

    public class TeachersController1 : Controller
    {
        private IRepository<Teacher> _context;

        public TeachersController1(TeacherRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.GetAll());
        }

        public IActionResult Details(Guid id)
        {
            var teacher = _context.GetById(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,UserName,Password,EmailAddress")] TeacherIndexListingModel teacherModel)
        {
            if (ModelState.IsValid)
            {
                var teacher = new Teacher
                {
                    Id = Guid.NewGuid(),
                    FirstName = teacherModel.FirstName,
                    LastName = teacherModel.LastName,
                    UserName = teacherModel.UserName,
                    Password = teacherModel.Password,
                    EmailAddress = teacherModel.EmailAddress
                };
                _context.Create(teacher);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(teacherModel);
        }

        public IActionResult Edit(Guid id)
        {
            var teacher = _context.GetById(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (Guid id, [Bind("FirstName, LastName, UserName, Password, EmailAddress")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.Update(teacher);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }
    }
}