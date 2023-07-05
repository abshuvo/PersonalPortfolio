using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigiPortfoli.Models;
using DigiPortfoli.Models.Entities;

namespace DigiPortfoli.Controllers
{
    public class EducationInfoesController : Controller
    {
        private readonly DBConfiguration _context;

        public EducationInfoesController(DBConfiguration context)
        {
            _context = context;
        }

        // GET: EducationInfoes
        public async Task<IActionResult> Index()
        {
              return _context.EducationInfo != null ? 
                          View(await _context.EducationInfo.ToListAsync()) :
                          Problem("Entity set 'DBConfiguration.EducationInfo'  is null.");
        }

        // GET: EducationInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EducationInfo == null)
            {
                return NotFound();
            }

            var educationInfo = await _context.EducationInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationInfo == null)
            {
                return NotFound();
            }

            return View(educationInfo);
        }

        // GET: EducationInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducationInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TITLE,StartDate,EndDate,Department,Institution,Description,Grade")] EducationInfo educationInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educationInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educationInfo);
        }

        // GET: EducationInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EducationInfo == null)
            {
                return NotFound();
            }

            var educationInfo = await _context.EducationInfo.FindAsync(id);
            if (educationInfo == null)
            {
                return NotFound();
            }
            return View(educationInfo);
        }

        // POST: EducationInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TITLE,StartDate,EndDate,Department,Institution,Description,Grade")] EducationInfo educationInfo)
        {
            if (id != educationInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationInfoExists(educationInfo.Id))
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
            return View(educationInfo);
        }

        // GET: EducationInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EducationInfo == null)
            {
                return NotFound();
            }

            var educationInfo = await _context.EducationInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationInfo == null)
            {
                return NotFound();
            }

            return View(educationInfo);
        }

        // POST: EducationInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EducationInfo == null)
            {
                return Problem("Entity set 'DBConfiguration.EducationInfo'  is null.");
            }
            var educationInfo = await _context.EducationInfo.FindAsync(id);
            if (educationInfo != null)
            {
                _context.EducationInfo.Remove(educationInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationInfoExists(int id)
        {
          return (_context.EducationInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
