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
    public class DetailsController : Controller
    {
        private readonly IRepository _context;

        public DetailsController(IRepository context)
        {
            _context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll<Detail>());
        }


        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var detail = await _context.GetById<Detail>(id);

            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
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
        public async Task<IActionResult> Create([Bind("Id,CheckIn,CheckOut,FeedbackMessage,NoOfPages,Rating")] DetailModel detailModel)
        {
            if (ModelState.IsValid)
            {
                var detail = new Detail
                {
                    Id = Guid.NewGuid(),
                    CheckIn = detailModel.CheckIn,
                    CheckOut = detailModel.CheckOut,
                    FeedbackMessage = detailModel.FeedbackMessage,
                    NoOfPages = detailModel.NoOfPages,
                    Rating = detailModel.Rating
                };
                _context.Create(detail);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(detailModel);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {

            var detail = await _context.GetById<Detail>(id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CheckIn,CheckOut,FeedbackMessage,NoOfPages,Rating")] Detail detail)
        {
            if (id != detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detail);
                    _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await TeacherExists(detail.Id)))
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

            return View(detail);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail = await _context.GetById<Detail>(id);

            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var detail = await _context.GetById<Detail>(id);
            _context.Delete(detail);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TeacherExists(Guid id)
        {
            var detail = await _context.GetById<Detail>(id);
            if (detail == null)
            {
                return false;
            }

            return true;
        }
    }
}
